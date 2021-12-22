using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Serilog;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Infrastructure;
using TaskToOctopus.Infrastructure.Extensions;
using TaskToOctopus.Persistence;
using TaskToOctopus.Persistence.Context;
using TaskToOctopus.Server;
using TaskToOctopus.Server.Services;

public class Program
{
    public static IConfiguration Configuration { get; set; }
    public static AppSettings AppSettings { get; set; }

    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => {
                var configBuilder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", optional: true);

                var config = configBuilder.Build();

                Log.Logger = new LoggerConfiguration()
                            .ReadFrom
                            .Configuration(config)
                            .CreateLogger();

                AppSettings = new AppSettings();
                config.Bind(AppSettings);

                Configuration = config;

                var sp = services.AddLogging(b => b.AddConsole())
                    .AddSingleton<IConfiguration>(Configuration)
                    .BuildServiceProvider();
                
                services.AddPersistence(AppSettings);
                
                services.AddDomain(AppSettings);

                services.AddRepositories(AppSettings);
                
                services.AddInfrastructure(AppSettings);
                
                services.AddServices(AppSettings);

                var logger = sp.GetService<ILoggerFactory>().CreateLogger<CRMSSODbContext>();
                
                Log.Logger.Debug("Starting Appplication TaskToOctopus.Server");

                logger.LogDebug("Starting Logger Context DB");
                
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
            .UseWindowsService();
}
