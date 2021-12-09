using Microsoft.EntityFrameworkCore;
using TaskToOctopus.Server.ActionModels;

#nullable disable

namespace TaskToOctopus.Server.ActionData
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

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsersNot> AspNetUsersNots { get; set; }
        public virtual DbSet<AspUsersHubConnection> AspUsersHubConnections { get; set; }
        public virtual DbSet<AspNetUsersRel> AspNetUsersRels { get; set; }
        public virtual DbSet<SSODealer> SSODealers { get; set; }
        public virtual DbSet<SSODealerInterfaceLogin> SSODealerInterfaceLogins { get; set; }
        public virtual DbSet<SSODealerRel> SSODealerRels { get; set; }
        public virtual DbSet<SSODealerUserStatus> SSODealerUserStatuses { get; set; }
        public virtual DbSet<SSODealersSubcscription> SSODealersSubcscriptions { get; set; }
        public virtual DbSet<SSODealersSubscriptionItem> SSODealersSubscriptionItems { get; set; }
        public virtual DbSet<SSOProcedure> SSOProcedures { get; set; }
        public virtual DbSet<SSOProcedureDealer> SSOProcedureDealers { get; set; }
        public virtual DbSet<T_Subscription> T_Subscriptions { get; set; }
        public virtual DbSet<T_SubscriptionFeeMethodDef> T_SubscriptionFeeMethodDefs { get; set; }
        public virtual DbSet<T_SubscriptionParDef> T_SubscriptionParDefs { get; set; }
        public virtual DbSet<T_SubscriptionPeriodBaseDef> T_SubscriptionPeriodBaseDefs { get; set; }
        public virtual DbSet<T_SubscriptionTypeDef> T_SubscriptionTypeDefs { get; set; }
        public virtual DbSet<__MigrationHistory> __MigrationHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("data source=192.168.204.100;initial catalog=CRMSSO;persist security info=True;user id=rsappuser;password=pupi@Trerot01!;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasOne(d => d.DealerKeyNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.DealerKey)
                    .HasConstraintName("FK_AspNetUsers_SSODealer");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

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
            modelBuilder.Entity<AspNetUsersRel>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.ParentID });
            });

            modelBuilder.Entity<SSODealer>(entity =>
            {
                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SSODealers)
                    .HasForeignKey(d => d.SubscriptionID)
                    .HasConstraintName("FK_SSODealers_T_Subscription");
            });

            modelBuilder.Entity<SSODealerInterfaceLogin>(entity =>
            {
                entity.HasKey(e => new { e.DealerKey, e.InterfaceID });

                entity.HasOne(d => d.DealerKeyNavigation)
                    .WithMany(p => p.SSODealerInterfaceLogins)
                    .HasForeignKey(d => d.DealerKey)
                    .HasConstraintName("FK_SSODealerInterfaceLogin_SSODealers");
            });

            modelBuilder.Entity<SSODealerRel>(entity =>
            {
                entity.HasKey(e => new { e.DealerKey, e.ParentKey })
                    .HasName("PK_SSODealerRel_1");

                entity.HasOne(d => d.ParentKeyNavigation)
                    .WithMany(p => p.SSODealerRels)
                    .HasForeignKey(d => d.ParentKey)
                    .HasConstraintName("FK_SSODealerRel_SSODealers");
            });

            modelBuilder.Entity<SSODealerUserStatus>(entity =>
            {
                entity.HasKey(e => new { e.DealerKey, e.RefDate, e.SSOUserID });
            });

            modelBuilder.Entity<SSODealersSubcscription>(entity =>
            {
                entity.HasOne(d => d.DealerKeyNavigation)
                    .WithMany(p => p.SSODealersSubcscriptions)
                    .HasForeignKey(d => d.DealerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SSODealersSubcscription_SSODealers");
            });

            modelBuilder.Entity<SSODealersSubscriptionItem>(entity =>
            {
                entity.HasOne(d => d.DealerSubscription)
                    .WithMany(p => p.SSODealersSubscriptionItems)
                    .HasForeignKey(d => d.DealerSubscriptionID)
                    .HasConstraintName("FK_SSODealersSubscriptionItem_SSODealersSubcscription");
            });

            modelBuilder.Entity<SSOProcedureDealer>(entity =>
            {
                entity.HasKey(e => new { e.ProcedureID, e.DealerKey });

                entity.HasOne(d => d.DealerKeyNavigation)
                    .WithMany(p => p.SSOProcedureDealers)
                    .HasForeignKey(d => d.DealerKey)
                    .HasConstraintName("FK_SSOProcedureDealer_SSODealers");

                entity.HasOne(d => d.Procedure)
                    .WithMany(p => p.SSOProcedureDealers)
                    .HasForeignKey(d => d.ProcedureID)
                    .HasConstraintName("FK_SSOProcedureDealer_SSOProcedures");
            });

            modelBuilder.Entity<T_Subscription>(entity =>
            {
                entity.HasOne(d => d.SubscriptionType)
                    .WithMany(p => p.T_Subscriptions)
                    .HasForeignKey(d => d.SubscriptionTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Subscription_T_SubscriptionTypeDef");
            });

            modelBuilder.Entity<T_SubscriptionFeeMethodDef>(entity =>
            {
                entity.Property(e => e.FeeMethodID).ValueGeneratedNever();

                entity.HasOne(d => d.PeriodBase)
                    .WithMany(p => p.T_SubscriptionFeeMethodDefs)
                    .HasForeignKey(d => d.PeriodBaseID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_SubscriptionFeeMethodDef_T_SubscriptionPeriodBaseDef");
            });

            modelBuilder.Entity<T_SubscriptionParDef>(entity =>
            {
                entity.HasKey(e => e.ParameterID)
                    .HasName("PK_T_SubcriptionParDef");
            });

            modelBuilder.Entity<T_SubscriptionTypeDef>(entity =>
            {
                entity.Property(e => e.SubcriptionTypeID).ValueGeneratedNever();

                entity.HasOne(d => d.FeeMethod)
                    .WithMany(p => p.T_SubscriptionTypeDefs)
                    .HasForeignKey(d => d.FeeMethodID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_SubscriptionTypeDef_T_SubscriptionFeeMethodDef");
            });

            modelBuilder.Entity<__MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
