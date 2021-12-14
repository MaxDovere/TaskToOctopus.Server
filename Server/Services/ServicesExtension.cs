using Microsoft.Extensions.DependencyInjection;
using TaskToOctopus.Domain.Services;

namespace TaskToOctopus.Server.Services
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection serviceCollection, AppSettings appSettings)
        {

            serviceCollection.AddSingleton<IMonitorService, MonitorService>();
        }
    }
}