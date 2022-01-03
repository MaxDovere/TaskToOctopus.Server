using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Diagnostics;
using System.IO;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Infrastructure;
using TaskToOctopus.Infrastructure.Extensions;
using TaskToOctopus.Infrastructure.Services;
using TaskToOctopus.Persistence;
using TaskToOctopus.Persistence.Logging;

public class Program
{
    //public static IConfiguration Configuration { get; set; }
    //public static AppSettings appSettings { get; set; }

    private static readonly INLogger<Program> _logger = new NLogger<Program>();
    public static void Main(string[] args)
    {

        try
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            _logger.LogInformation("Starting up the service");
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            IMonitorService monitorLoop = host.Services.GetRequiredService<IMonitorService>()!;
            monitorLoop.StartMonitorLoop();

            host.Run();
        }
        catch (Exception ex)
        {
            _logger.LogFatal(ex, "There was a problem starting the serivce");
        }
        finally
        {
            NLog.LogManager.Shutdown();
        }
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => {

                var pathToExe = Process.GetCurrentProcess().MainModule?.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                //Path.Combine(AppContext.BaseDirectory, "myfile.json")

                var configBuilder = new ConfigurationBuilder()
                                   .SetBasePath(pathToContentRoot) //System.IO.Directory.GetCurrentDirectory())
                                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                   //.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                                   .Build();

                var appSettings = new AppSettings();
                configBuilder.Bind(appSettings);
                
                services.AddSingleton<AppSettings>(appSettings);

                services.AddNLogLogging(configBuilder);

                _logger.LogInformation("Startup services Install!");

                services.AddPersistence(appSettings);

                services.AddRepositories(appSettings);
                
                services.AddInfrastructure(appSettings);

                //var logger = sp.GetService<ILoggerFactory>().CreateLogger<CRMSSODbContext>();
                //logger.LogDebug("Starting Logger Context DB");

                _logger.LogDebug("Starting Appplication TaskToOctopus.Server");

                /*
                 * istanzio l'oggetto che sarà il monitor degli altri oggetti per le parti in background
                 * e lo attivo come servizio windows. Andrà installato nel Server Control della macchina e 
                 * attivato con l'avvio e lo stop manuale.
                 */
                services.AddHostedService<QueuedHostedService>();
                    //.Configure<EventLogSettings>(config =>
                    //{
                    //    config.LogName = "Task Octopus Notification Service";
                    //    config.SourceName = "Task Octopus Notification Service Source";
                    //});

            })
            .UseWindowsService(config =>
            {
                config.ServiceName = "Task Octopus Notificator Service 1.0";
            })
            .ConfigureLogging(logging =>
            {
                logging.AddEventLog(config =>
                {
                    config.LogName = "Task Octopus Notification Service";
                    config.SourceName = "Task Octopus Notification Service Source";
                });
            })
            .UseNLog();
}
