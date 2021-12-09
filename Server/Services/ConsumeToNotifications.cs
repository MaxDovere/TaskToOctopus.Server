using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Server.ActionModels;
using TaskToOctopus.Server.Models;
using TaskToOctopus.Server.Repositories;

namespace TaskToOctopus.Server.Services
{
    public class ConsumeToNotifications : IConsumeToNotifications
    {
        private readonly ILogger<ConsumeToNotifications> _logger;
        private readonly IUnitOfWork _uow;
        public SortedDictionary<string, string> WorkersToNotify { get; set; } = new SortedDictionary<string, string>();
        public ConsumeToNotifications(ILogger<ConsumeToNotifications> logger, IUnitOfWork uow)
        {
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

            foreach(var item in workers)
            {
                wks.Add(new WorkerModel()
                {
                    UserId = item,
                    BaseUrl = "http://localhost:56179",
                    Endpoint = "home/UpdateMessages",
                    Method = "GET"
                });
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

            _logger.LogInformation("Queued Background Task {Guid} is starting.{json}", data.Key, json);

            //while (!token.IsCancellationRequested && WorkersToNotify.Count > 0)
            //{
            try
            {
        
                _logger.LogInformation("Queued Background Task {Guid} is running.", data.Key);
                /*
                 * preso il dato per il worker, se la lista è ancora piena elimina la sua chiave nella lista
                 * cosi lascia al successivo worker di prendersi il suo parametro.
                */
                if (WorkersToNotify.Count > 0) WorkersToNotify.Remove(data.Key);
                    
                Console.WriteLine($"{data.Key} - {datajson}");

                await CallNotificationMessages(data.Key, work);

                /*
                * Simulo un lavoro di notifica [Attende 15 secondi]
                */

                await Task.Delay(TimeSpan.FromSeconds(15), token);

                _logger.LogInformation("Queued Background Task {Guid} is complete.", data.Key);
            }
            catch (OperationCanceledException)
            {
                // Prevent throwing if the Delay is cancelled
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
                //delayLoop++;

                //_logger.LogInformation("Queued Background Task {Guid} is running." + "{DelayLoop}/3", guid, delayLoop);
            //}

            if(token.IsCancellationRequested)
            {
                _logger.LogInformation("Queued Background Task {Guid} was cancelled.", data.Key);
            }
        }
        public async Task CallNotificationMessages(string userid, WorkerModel work)
        {
            try
            {
                var client = new RestClient(work.BaseUrl);
                var request = new RestRequest(work.Endpoint + $"?userid='{work.UserId}'", work.Method == "GET" ? Method.GET : Method.POST);
                if (work.Method == "POST")
                {
                    request.AddJsonBody(work);
                }
                var response = client.Execute(request);

                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                    _logger.LogWarning($"Error StatusCode: {response.StatusCode} Description: " + response.ErrorMessage);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }

            //_logger.LogInformation($"Task notificato! {json}");
            await Task.CompletedTask;
        }
    }
}
