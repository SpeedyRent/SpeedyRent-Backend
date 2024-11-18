using Microsoft.EntityFrameworkCore;
using Login_back.Domain.Model;

namespace Login_back.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(o => o.OwnerUserId);

            modelBuilder.Entity<Tenant>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.TenantUserId);
        }
    }
}