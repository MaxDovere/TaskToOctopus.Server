using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Infrastructure.Interfaces;
using TaskToOctopus.Persistence.Logging;

namespace TaskToOctopus.Infrastructure
{
    public class QueuedHostedService : BackgroundService
    {
        private readonly INLogger<QueuedHostedService> _logger = new NLogger<QueuedHostedService>();

        public IBackgroundTaskQueue TaskQueue { get; }

        public QueuedHostedService(IBackgroundTaskQueue taskQueue)
        {
            TaskQueue = taskQueue;
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
            string json = ""; // eventuale parametro json da passare al processo

            _logger.LogInformation(
                $"Queued Hosted Service is running.{Environment.NewLine}" +
                $"background queue.{Environment.NewLine}");
            

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
                    _logger.LogError(ex, $"Error occurred executing {nameof(workItem)}.");
                }                
            }
        }


    }
}
