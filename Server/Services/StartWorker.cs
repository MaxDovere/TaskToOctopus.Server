using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskToOctopus.Server.Services
{
    public class StartWorker : BackgroundService
    {
        private readonly ILogger<StartWorker> _logger;
        private readonly IMonitorService _monitor;
        public StartWorker(ILogger<StartWorker> logger, IMonitorService monitor)
        {
            _logger = logger;
            _monitor = monitor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //if(!_monitor.Status)
                _monitor.StartMonitorLoop();
                await Task.Delay(15000, stoppingToken);
            }
        }
    }
}