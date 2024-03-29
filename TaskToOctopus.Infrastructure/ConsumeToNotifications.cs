﻿using Microsoft.Extensions.Logging;
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

            var workers = _uow.GetActiveDealerInfo();
            if (workers == null)
                return Task.FromResult(wks.ToList());

            var setting = _appSettings.Settings;

            foreach (var item in workers)
            {
                if(setting.DefaultEndpoint.Length == 0)
                    wks.Add(new WorkerModel(item.SSODealerID, item.DBName, item.CRMLink, setting.DefaultNotificator, setting.Method));
                else
                    wks.Add(new WorkerModel(item.SSODealerID, item.DBName , setting.DefaultEndpoint, setting.DefaultNotificator, setting.Method));
            }

            return Task.FromResult(wks.ToList());
        }
        public async ValueTask BuildWorkNotify(string parameter, CancellationToken token)
        {
            /*
             * Prende il primo contenutore di parametri salvato sulla SortedDictionary 
             * e passati dall'istanza del worker 
            */
            if (WorkersToNotify == null)
                await Task.CompletedTask;

            var data = WorkersToNotify.OrderBy(x => x.Key).First();
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
                await Task.FromException(op);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                _logger.LogError(e, e.Message);
                await Task.FromException(e);
            }

            if (token.IsCancellationRequested)
            {
                _logger.LogWarning($"Queued Background Task {data.Key} was cancelled.");
                await Task.FromCanceled(token);
            }
            await Task.CompletedTask;
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
                    request.AddQueryParameter("dealerkey", work.SSODealerID);
                    request.AddQueryParameter("connname", work.ConnName);
                }

                //request.AddHeader("origin", "http://tasktooctopus.net");
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
