using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Server.ActionModels;
using TaskToOctopus.Server.Models;

namespace TaskToOctopus.Server.Services
{
    public class MonitorService : IMonitorService
    {
        private readonly IConsumeToNotifications _notify;
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly ILogger _logger;
        private readonly CancellationToken _cancellationToken;

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

        public void StartMonitorLoop()
        {
            _logger.LogInformation("MonitorAsync Loop is starting.");

            // Run a console user input loop in a background thread
            Task.Run(async () => await MonitorAsync());

        }

        private async ValueTask MonitorAsync()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                IEnumerable<WorkerModel> workers =
                        Task.Run(
                                () => _notify.GetWorkerNotificator(_cancellationToken)
                        ).Result;

                if (workers != null)
                {
                    foreach (var work in workers)
                    {
                        string json = JsonConvert.SerializeObject(work);
                        _notify.WorkersToNotify.Add(work.UserId, json); // $"BuildWorkNotify?userid:{work.UserId}");
                        // Enqueue a background work item
                        await _taskQueue.QueueBackgroundWorkItemAsync(_notify.BuildWorkNotify);
                    }
                }
            }
        }
    }
}
