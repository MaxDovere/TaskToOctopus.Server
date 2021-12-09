using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskToOctopus.Server.Models;

#nullable disable

namespace TaskToOctopus.Server.Data
{
    public partial class OctopusNotificationsDbContext : DbContext
    {
        public OctopusNotificationsDbContext()
        {
        }

        public OctopusNotificationsDbContext(DbContextOptions<OctopusNotificationsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MainMessageNotification> MainMessageNotifications { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<UserWhoNotification> UserWhoNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("data source=HPMAX1966;initial catalog=OctopusNotifications;persist security info=True;user id=sa;password=w7admin;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<MainMessageNotification>(entity =>
            {
                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ByWho)
                    .WithMany(p => p.NotificationByWhos)
                    .HasForeignKey(d => d.ByWhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_MainMessageNotifications");
            });

            modelBuilder.Entity<UserWhoNotification>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Method).HasDefaultValueSql("('POST')");
            });

            modelBuilder.Entity<V_MessagesNotification>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("V_MessagesNotification");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
