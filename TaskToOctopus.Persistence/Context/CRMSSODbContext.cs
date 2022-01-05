using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TaskToOctopus.Domain.Model;

namespace TaskToOctopus.Persistence.Context
{
    public partial class CRMSSODbContext : DbContext
    {
        public CRMSSODbContext()
        {
        }

        public CRMSSODbContext(DbContextOptions<CRMSSODbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DealerInfoModel> DealerInfo { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUsersNot> AspNetUsersNots { get; set; }
        public virtual DbSet<AspUsersHubConnection> AspUsersHubConnections { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AspNetUsersNot>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.LeadPlanActivityID });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUsersNots)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_AspNetUsersNot_AspNetUsers");
            });

            modelBuilder.Entity<AspUsersHubConnection>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspUsersHubConnections)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_AspUsersHubConnection_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
