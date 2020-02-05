using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirst.ModelDB
{
    public partial class CcfTestContext : DbContext
    {
        public CcfTestContext()
        {
        }

        public CcfTestContext(DbContextOptions<CcfTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestUser> TestUser { get; set; }
        public virtual DbSet<TestUserInfo> TestUserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TestUser>(entity =>
            {
                entity.HasKey(e => e.IdTestUser);

                entity.Property(e => e.IdTestUser)
                    .HasColumnName("idTestUser")
                    .ValueGeneratedNever();

                entity.Property(e => e.JoinDate).IsRequired();
            });

            modelBuilder.Entity<TestUserInfo>(entity =>
            {
                entity.HasKey(e => e.IdTestUserInfo);

                entity.HasIndex(e => e.IdTestUserForeignKey);

                entity.Property(e => e.IdTestUserInfo)
                    .HasColumnName("idTestUserInfo")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTestUserForeignKey).HasColumnName("idTestUserForeignKey");

                entity.HasOne(d => d.IdTestUserForeignKeyNavigation)
                    .WithMany(p => p.TestUserInfo)
                    .HasForeignKey(d => d.IdTestUserForeignKey);
            });
        }
    }
}
