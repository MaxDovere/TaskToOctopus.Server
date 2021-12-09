using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using System.Threading.Tasks;
using TaskToOctopus.Server.ActionData;
using TaskToOctopus.Server.Repositories;
using TaskToOctopus.Server.Services;

//using var host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices((hostContext, services) =>
//    {

//        var configBuilder = new ConfigurationBuilder()
//                                .AddJsonFile("appsettings.json", optional: true);

//        var config = configBuilder.Build();

//        var sp = new ServiceCollection()
//            .AddLogging(b => b.AddConsole())
//            .AddSingleton<IConfiguration>(config)
//            .BuildServiceProvider();

//        var logger = sp.GetService<ILoggerFactory>().CreateLogger<OctopusNotificationsDbContext>();

//        logger.LogDebug("Starting");

//        services.AddDbContext<OctopusNotificationsDbContext>(options =>
//            options.UseSqlServer(config.GetConnectionString("OctopusNotifications")));

//        services.AddSingleton<MonitorLoop>();
//        services.AddHostedService<QueuedHostedService>();
//        services.AddSingleton<IBackgroundTaskQueue>(ctx =>
//            {
//                if (!int.TryParse(hostContext.Configuration["QueueCapacity"], out var queueCapacity))
//                    queueCapacity = 100;
//                return new BackgroundTaskQueue(queueCapacity);
//            });
//        services.AddTransient<IUnitOfWork, UnitOfWork>();
//        services.AddSingleton<IConsumeToNotifications, ConsumeToNotifications>();

//    })
//    .Build();

//await host.StartAsync();

//var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
//monitorLoop.StartMonitorLoop();

//await host.WaitForShutdownAsync();
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();

        //using var host = CreateHostBuilder(args).Build();

        //await host.StartAsync();

        //var monitorLoop = host.Services.GetRequiredService<MonitorService>();
        //monitorLoop.StartMonitorLoop();

        //await host.WaitForShutdownAsync();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => {
                var configBuilder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", optional: true);

                var config = configBuilder.Build();

                var sp = new ServiceCollection()
                    .AddLogging(b => b.AddConsole())
                    .AddSingleton<IConfiguration>(config)
                    .BuildServiceProvider();

                var logger = sp.GetService<ILoggerFactory>().CreateLogger<CRMSSODbContext>();

                logger.LogDebug("Starting");

                services.AddDbContext<CRMSSODbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("CRMSSOEntities")));

                services.AddSingleton<IMonitorService,MonitorService>();
                services.AddHostedService<QueuedHostedService>();
                services.AddSingleton<IBackgroundTaskQueue>(ctx =>
                {
                    if (!int.TryParse(hostContext.Configuration["QueueCapacity"], out var queueCapacity))
                        queueCapacity = 100;
                    return new BackgroundTaskQueue(queueCapacity);
                });
                services.AddTransient<IUnitOfWork, UnitOfWork>();
                services.AddSingleton<IConsumeToNotifications, ConsumeToNotifications>();
                /*
                 * istanzio l'oggetto che sarà il monitor degli altri oggetti per le parti in background
                 * e lo attivo come servizio windows. Andrà installato nel Server Control della macchina e 
                 * attivato con l'avvio e lo stop manuale.
                 */
                services.AddHostedService<StartWorker>()
                    .Configure<EventLogSettings>(config =>
                    {
                        config.LogName = "Task Octopus Notification Service";
                        config.SourceName = "Task Octopus Notification Service Source";
                    });

            })
            .UseWindowsService();
}
