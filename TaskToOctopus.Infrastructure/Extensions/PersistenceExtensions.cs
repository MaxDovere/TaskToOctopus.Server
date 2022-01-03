using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskToOctopus.Domain.Services;
using TaskToOctopus.Persistence.Context;

namespace TaskToOctopus.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static void AddPersistence(this IServiceCollection serviceCollection, AppSettings appSettings)
        {
            serviceCollection.AddDbContext<CRMSSODbContext>(options =>
                options.UseSqlServer(appSettings.ConnectionStrings.CRMSSOEntities)); //config.GetConnectionString("CRMSSOEntities")));
        }
    }
}
