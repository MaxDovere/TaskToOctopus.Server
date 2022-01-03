using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Domain.Model;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Infrastructure.Interfaces;
using TaskToOctopus.Infrastructure.Repositories;

namespace TaskToOctopus.Infrastructure
{
    public class ConsumeToNotifications : IConsumeToNotifications
    {
        //private readonly INLogger<ConsumeToNotifications> _logger = new NLogger<ConsumeToNotifications>();
        private readonly ILogger<ConsumeToNotifications> _logger;
        private readonly IUnitOfWork _uow;
        private readonly AppSettings _appSettings;
        public SortedDictionary<string, string> WorkersToNotify { get; set; } = new SortedDictionary<string, string>();
        public ConsumeToNotifications(ILogger<ConsumeToNotifications> logger, IUnitOfWork uow, AppSettings appSettings)
        {
            _appSettings = appSettings;
            _logger = logger;
            _uow = uow;
        }
        public Task<List<WorkerModel>> GetWorkerNotificator(CancellationToken token)
        {
            var wks = new List<WorkerModel>();

            var messages = _uow.GetMessagesToNotifiction();
            if (messages == null)
                return Task.FromResult(wks.ToList());

            var workers = (from table in messages
                           select table)
                       .Select(field => field.UserID)
                       .Distinct()
                       .ToList();

            foreach (var item in workers)
            {
                SSODealer info = _uow.GetActiveDealerInfo(item);

                if(_appSettings.Settings.DefaultEndpoint.Length == 0)
                    wks.Add(new WorkerModel(item, info.CRMLink, "api/backend/messages", "GET"));
                else
                    wks.Add(new WorkerModel(item, _appSettings.Settings.DefaultEndpoint, "api/backend/messages", "GET"));
            }

            return Task.FromResult(wks.ToList());
        }
        public async ValueTask BuildWorkNotify(string parameter, CancellationToken token)
        {
            /*
             * Prende il primo contenutore di parametri salvato sulla SortedDictionary 
             * e passati dall'istanza del worker 
            */
            var data = WorkersToNotify.First();
            string datajson = data.Value.ToString();
            WorkerModel work = JsonConvert.DeserializeObject<WorkerModel>(datajson);

            _logger.LogInformation($"Queued Background Task {data.Key} is starting.");

            try
            {
                //_logger.LogWarning($"Queued Background Task {data.Key} is running.");
                /*
                 * preso il dato per il worker, se la lista è ancora piena elimina la sua chiave nella lista
                 * cosi lascia al successivo worker di prendersi il suo parametro.
                */
                if (WorkersToNotify.Count > 0) WorkersToNotify.Remove(data.Key);

                //_logger.LogInformation($"Queued Background Task {data.Key} - {datajson}");

                await CallNotificationMessages(data.Key, work);

                _logger.LogInformation($"Queued Background Task {data.Key} is complete.");
            }
            catch (OperationCanceledException op)
            {
                // Prevent throwing if the Delay is cancelled
                _logger.LogError(op, op.Message);

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                _logger.LogError(e, e.Message);
            }

            if (token.IsCancellationRequested)
            {
                _logger.LogWarning($"Queued Background Task {data.Key} was cancelled.");
            }
        }
        public async Task CallNotificationMessages(string userid, WorkerModel work)
        {
            try
            {
                var client = new RestClient(work.BaseUrl);
                var request = new RestRequest(work.Endpoint, work.Method == "GET" ? Method.GET : Method.POST);
                if (work.Method == "POST")
                {
                    request.AddJsonBody(work);
                }
                if (work.Method == "GET")
                {
                    request.AddQueryParameter("userid", work.UserId);
                }

                request.AddHeader("origin", "http://tasktooctopus.net");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    _logger.LogInformation($"StatusCode: {response.StatusCode} - Destination: {response.ResponseUri.ToString()} - Description: {response.Content}");
                else
                    _logger.LogWarning($"StatusCode: {response.StatusCode} - Destination: {response.ResponseUri?.ToString()} - Description: {(response.ErrorMessage == null ? "Il link in cui notificare non sembra attivo o connesso!" : response.ErrorMessage)}");

            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            await Task.CompletedTask;
        }

        public bool IsValidConnection()
        {
            return _uow.IsValidateDB();
        }
    }
}
