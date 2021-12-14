using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Domain.Model;
using TaskToOctopus.Infrastructure.Interfaces;

namespace TaskToOctopus.Server.Services
{
    public class MonitorService : IMonitorService
    {
        private readonly IConsumeToNotifications _notify;
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly ILogger _logger;
        private readonly CancellationToken _cancellationToken;
        private readonly CancellationTokenSource controller = new CancellationTokenSource();
        private int hashCode = 0;

        public MonitorService(IConsumeToNotifications notify,
            IBackgroundTaskQueue taskQueue,
            ILogger<MonitorService> logger,
            IHostApplicationLifetime applicationLifetime)
        {
            _notify = notify;
            _taskQueue = taskQueue;
            _logger = logger;
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        public void StartMonitorLoop(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MonitorAsync Loop is starting.");
            cancellationToken.Register(() =>
            {
                StopMonitorLoop(_cancellationToken, "Request cancelled!");
            });
            /*
             * Accettarsi che la connessione sia corretta validando il contatto con il database eventuale 
            */
            try
            {
                var test = _notify.IsValidConnection();
                if (!test) controller.CancelAfter(1); //valore in millesecondi.
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }


            // Run a console user input loop in a background thread
            Task.Run(async () => await MonitorAsync());

        }

        public void StopMonitorLoop(CancellationToken cancellationToken, string message)
        {
            _logger.LogInformation(message);
            controller.Dispose();
        }

        private async ValueTask MonitorAsync()
        {
            
            try
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    List<WorkerModel> workers =
                            Task.Run(
                                    () => _notify.GetWorkerNotificator(_cancellationToken)
                            ).Result;

                    if (workers != null && workers.Count > 0 && workers.GetHashCode() != hashCode)
                    {
                        hashCode = workers.GetHashCode();
                        foreach (var work in workers)
                        {
                            string userid = work.UserId;
                            if (_notify.WorkersToNotify.ContainsKey(work.UserId))
                            {
                                _notify.WorkersToNotify.Remove(userid);
                            }
                            string json = JsonConvert.SerializeObject(work);
                            _notify.WorkersToNotify.Add(userid, json); // $"BuildWorkNotify?userid:{work.UserId}");
                                                                                // Enqueue a background work item
                            await _taskQueue.QueueBackgroundWorkItemAsync(_notify.BuildWorkNotify);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
