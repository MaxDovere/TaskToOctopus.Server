using Microsoft.Extensions.DependencyInjection;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Infrastructure.Repositories;

namespace TaskToOctopus.Infrastructure.Extensions
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, AppSettings appSettings)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
