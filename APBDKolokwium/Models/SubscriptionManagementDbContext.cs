using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APBDKolokwium.Models
{
    public class SubscriptionManagementDbContext : DbContext
    {
        public SubscriptionManagementDbContext() { }

        public SubscriptionManagementDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
