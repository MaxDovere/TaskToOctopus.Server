using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using NLog.Web;
using System;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Infrastructure.Extensions;
using TaskToOctopus.Persistence;
using TaskToOctopus.Persistence.Logging;
using TaskToOctopus.Server;
using TaskToOctopus.Server.Services;

public class Program
{
    public static IConfiguration Configuration { get; set; }
    public static AppSettings appSettings { get; set; }

    private static readonly INLogger<Program> _logger = new NLogger<Program>();
    public static void Main(string[] args)
    {

        try
        {
            _logger.LogInformation("Starting up the service");
            CreateHostBuilder(args).Build().Run();
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
                var configBuilder = new ConfigurationBuilder()
                                       .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                       .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                                       .Build();

                appSettings = new AppSettings();
                configBuilder.Bind(appSettings);

                Configuration = configBuilder;

                //var sp = services.AddLogging(b => b.AddConsole())
                //    .AddSingleton<IConfiguration>(Configuration)
                //    .BuildServiceProvider();

                services.AddSingleton<IConfiguration>(Configuration);

                services.AddNLogLogging(Configuration);

                _logger.LogInformation("Startup services Install!");

                services.AddPersistence(appSettings);
                
                services.AddDomain(appSettings);

                services.AddRepositories(appSettings);
                
                services.AddInfrastructure(appSettings);
                
                services.AddServices(appSettings);


                //var logger = sp.GetService<ILoggerFactory>().CreateLogger<CRMSSODbContext>();
                //logger.LogDebug("Starting Logger Context DB");

                _logger.LogDebug("Starting Appplication TaskToOctopus.Server");
                
                /*
                 * istanzio l'oggetto che sarà il monitor degli altri oggetti per le parti in background
                 * e lo attivo come servizio windows. Andrà installato nel Server Control della macchina e 
                 * attivato con l'avvio e lo stop manuale.
                 */
                services.AddHostedService<Startup>()
                    .Configure<EventLogSettings>(config =>
                    {
                        config.LogName = "Task Octopus Notification Service";
                        config.SourceName = "Task Octopus Notification Service Source";
                    });

            })
            .UseWindowsService()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
            })
            .UseNLog();
}
