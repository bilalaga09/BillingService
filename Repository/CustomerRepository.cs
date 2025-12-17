using BillingApp.Context;
using BillingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly BillingDbContext _billingDbContext;
        public CustomerRepository(BillingDbContext billingDbContext)
        {
            _billingDbContext = billingDbContext;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _billingDbContext.Customers
                .AsNoTracking()
                .Where(x => x.Active == 'Y')
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _billingDbContext.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Active == 'Y');
        }

        public async Task<int> Create(Customer customer)
        {
            // Ensure server-controlled fields have safe defaults
            customer.CreatedAt ??= DateTime.UtcNow;
            customer.Active = 'Y';

            _billingDbContext.Customers.Add(customer);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Customer customer)
        {
            _billingDbContext.Customers.Update(customer);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var customer = await _billingDbContext.Customers.FindAsync(id);
            if (customer == null) return 0;

            customer.Active = 'N';
            return await _billingDbContext.SaveChangesAsync();
        }

    }
}
