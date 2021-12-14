using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Infrastructure.Interfaces;

namespace TaskToOctopus.Infrastructure
{
   public class QueuedHostedService : BackgroundService
    {
        private readonly ILogger<QueuedHostedService> _logger;
        public IBackgroundTaskQueue TaskQueue { get; }

        public QueuedHostedService(IBackgroundTaskQueue taskQueue, ILogger<QueuedHostedService> logger)
        {
            TaskQueue = taskQueue;
            _logger = logger;
        }
        //public int GetHashCode(Validator v)
        //{
        //    int hCode = GetMyStringHash(v.GetType().GUID.ToString() + v.SomeState);
        //    // as for GetMyStringHash() implementation for this example, 
        //    // you can use some simple string hashing: 
        //    // http://www.techlicity.com/blog/dotnet-hash-algorithms.html
        //    return hCode;
        //}
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"Queued Hosted Service is running.{Environment.NewLine}" +
                $"{Environment.NewLine}Tap W to add a work item to the " +
                $"background queue.{Environment.NewLine}");
            
            string json = "dato numero q1";

            await BackgroundProcessing(json, stoppingToken);
        }
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queued Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
        private async Task BackgroundProcessing(string json, CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await TaskQueue.DequeueAsync(stoppingToken);

                try
                {
                    await workItem(json, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, 
                        "Error occurred executing {WorkItem}.", nameof(workItem));
                }                
            }
        }


    }
}
