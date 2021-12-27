using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Persistence.Logging;
using TaskToOctopus.Server.Services;

namespace TaskToOctopus.Server
{
    public class Startup : BackgroundService
    {
        private readonly INLogger<Startup> _logger = new NLogger<Startup>();

        private readonly IMonitorService _monitor;
        public Startup(IMonitorService monitor)
        {
            _monitor = monitor;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Startup (ExecuteAsync) running at: {DateTimeOffset.Now}");
                
                //EventLog.WriteEntry("Startup", $"EventLog: Worker running at: {DateTimeOffset.Now}");
                _monitor.StartMonitorLoop(stoppingToken);
                await Task.Delay(1500, stoppingToken);
            }
        }
    }
}