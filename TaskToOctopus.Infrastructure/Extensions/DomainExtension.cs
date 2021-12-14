using Microsoft.Extensions.DependencyInjection;
using TaskToOctopus.Domain.Port;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Infrastructure.Repositories;

namespace TaskToOctopus.Infrastructure.Extensions
{
    public static class DomainExtension
    {
        public static void AddDomain(this IServiceCollection serviceCollection, AppSettings appSettings)
        {
            serviceCollection.AddTransient(typeof(IRequestEntity<>), typeof(EntityDomain<>));
        }
    }
}
