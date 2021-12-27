using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Domain.Model;
using TaskToOctopus.Infrastructure.Interfaces;
using TaskToOctopus.Infrastructure.Repositories;
using TaskToOctopus.Persistence.Logging;

namespace TaskToOctopus.Infrastructure
{
    public class ConsumeToNotifications : IConsumeToNotifications
    {
        private readonly INLogger<ConsumeToNotifications> _logger = new NLogger<ConsumeToNotifications>();
        private readonly IUnitOfWork _uow;
        public SortedDictionary<string, string> WorkersToNotify { get; set; } = new SortedDictionary<string, string>();
        public ConsumeToNotifications(IUnitOfWork uow)
        {
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
            
            // link localhost "http://localhost:56179",

            foreach (var item in workers)
            {
                wks.Add(new WorkerModel(item, "http://localhost:54286", "api/backend/messages", "GET"));
            }

            return Task.FromResult(wks.ToList());
        }
        public async ValueTask BuildWorkNotify(string json, CancellationToken token)
        {
            /*
             * Prende il primo contenutore di parametri salvato sulla SortedDictionary 
             * e passati dall'istanza del worker 
            */
            var data = WorkersToNotify.First();
            string datajson = data.Value.ToString();
            WorkerModel work = JsonConvert.DeserializeObject<WorkerModel>(datajson);

            _logger.LogInformation($"Queued Background Task {data.Key} is starting. External parameter (json) {json}");

            try
            {        
                _logger.LogWarning($"Queued Background Task {data.Key} is running.");
                /*
                 * preso il dato per il worker, se la lista è ancora piena elimina la sua chiave nella lista
                 * cosi lascia al successivo worker di prendersi il suo parametro.
                */
                if (WorkersToNotify.Count > 0) WorkersToNotify.Remove(data.Key);
                
                _logger.LogInformation($"Queued Background Task {data.Key} - {datajson}");

                await CallNotificationMessages(data.Key, work);
                
                _logger.LogWarning($"Queued Background Task {data.Key} is complete.");
            }
            catch (OperationCanceledException op)
            {
                // Prevent throwing if the Delay is cancelled
                _logger.LogError(op.Message);

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                _logger.LogError(e.Message);
            }

            if(token.IsCancellationRequested)
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

                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                    _logger.LogWarning($"StatusCode: {response.StatusCode} - Description: " + response.ErrorMessage);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }

            _logger.LogWarning($"Task notificato! {System.Net.HttpStatusCode.OK}");
            await Task.CompletedTask;
        }

        public bool IsValidConnection()
        {
            return _uow.IsValidateDB(); 
        }
    }
}
