using BillingApp.Mappings;
using BillingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Context
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }
    }
}
