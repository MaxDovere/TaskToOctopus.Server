using SignalRDbUpdates.ActionModels;
using System.Data.Entity;

namespace SignalRDbUpdates.ActionData
{
    public partial class CRMSSODbContext : DbContext
    {
        public CRMSSODbContext()
        {
        }
        public virtual DbSet<AspUsersHubConnection> AspUsersHubConnections { get; set; }
    }
}
