using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Server.Services;

namespace TaskToOctopus.Server
{
    public class Startup : BackgroundService
    {
        private readonly ILogger<Startup> _logger;
        private readonly IMonitorService _monitor;
        public Startup(ILogger<Startup> logger, IMonitorService monitor)
        {
            _logger = logger;
            _monitor = monitor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _monitor.StartMonitorLoop(stoppingToken);
                await Task.Delay(15000, stoppingToken);
            }
        }
    }
}