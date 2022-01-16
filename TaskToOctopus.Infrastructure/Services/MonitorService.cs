using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Domain.Model;
using TaskToOctopus.Infrastructure.Interfaces;

namespace TaskToOctopus.Infrastructure.Services
{
    public class MonitorService: IMonitorService
    {
        //private static INLogger<MonitorService> _logger = new NLogger<MonitorService>();
        private readonly ILogger<MonitorService> _logger;
        private readonly IConsumeToNotifications _consumeNotify;
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly CancellationToken _cancellationToken;
        private readonly CancellationTokenSource controller = new CancellationTokenSource();
        private int hashCode = 0;

        public MonitorService(ILogger<MonitorService> logger, IConsumeToNotifications consume,
            IBackgroundTaskQueue taskQueue,
            IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _consumeNotify = consume;
            _taskQueue = taskQueue;
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        public async void StartMonitorLoop()
        {
            /*
             * Accettarsi che la connessione sia corretta validando il contatto con il database eventuale 
            */
            try
            {
                if (!_consumeNotify.IsValidConnection())
                    controller.CancelAfter(1); //valore in millesecondi.

                _logger.LogInformation("MonitorAsync Loop is starting.");
                await Task.Run(async () => await MonitorAsync());
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }

        }
        public void StopMonitorLoop(CancellationToken cancellationToken)
        {
            controller.Dispose();
            _logger.LogInformation("MonitorAsync Loop is stopping.");
        }
        private async ValueTask MonitorAsync()
        {
            try
            {
                List<WorkerModel> workers = new List<WorkerModel>();

                while (!_cancellationToken.IsCancellationRequested)
                {
                    workers = _consumeNotify.GetWorkerNotificator(_cancellationToken).Result;

                    if (workers.Any() && workers.GetHashCode() != hashCode)
                    {
                        hashCode = workers.GetHashCode();
                        foreach (var work in workers)
                        {
                            string SSODealerID = work.SSODealerID;
                            if (_consumeNotify.WorkersToNotify.ContainsKey(SSODealerID))
                            {
                                _consumeNotify.WorkersToNotify.Remove(SSODealerID);
                            }
                            string json = JsonConvert.SerializeObject(work);
                            _consumeNotify.WorkersToNotify.Add(SSODealerID, json);

                            _logger.LogInformation($"Enqueue a background Worker {SSODealerID} notify.");

                            await _taskQueue.QueueBackgroundWorkItemAsync(_consumeNotify.BuildWorkNotify);
                            await Task.Delay(TimeSpan.FromSeconds(5), _cancellationToken);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}
