using Microsoft.Extensions.DependencyInjection;
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
    }
}
