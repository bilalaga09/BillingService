using BillingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Context
{
    public class BillingDbContext : DbContext
    {
        public  BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
