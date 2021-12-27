using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Infrastructure.Interfaces;

namespace TaskToOctopus.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, AppSettings appSettings)
        {

            serviceCollection.AddHostedService<QueuedHostedService>();
            serviceCollection.AddSingleton<IBackgroundTaskQueue>(ctx =>
            {
                //if (!int.TryParse(hostContext.Configuration["QueueCapacity"], out var queueCapacity))
                if (!int.TryParse(appSettings.Settings.QueueCapacity.ToString(), out var queueCapacity))
                    queueCapacity = 100;
                return new BackgroundTaskQueue(queueCapacity);
            });

            serviceCollection.AddSingleton<IConsumeToNotifications, ConsumeToNotifications>();

        }
        public static void AddNLogLogging(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                loggingBuilder.AddNLog(configuration);
            });
        }

        //private void SetUpNLog()
        //{
        //    var config = new NLog.Config.LoggingConfiguration();
        //    // Targets where to log to: File and Console
        //    var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "backupclientlogfile_backupservice.txt" };
        //    var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
        //    // Rules for mapping loggers to targets            
        //    config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
        //    config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logfile);
        //    // Apply config           
        //    LogManager.Configuration = config;
        //    _logger = LogManager.GetCurrentClassLogger();
        //}
    }
}
