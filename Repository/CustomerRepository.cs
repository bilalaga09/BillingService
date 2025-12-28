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

        public async Task<(List<Customer> Items, int TotalCount)> GetAllCustomersPaged(int page, int pageSize)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = _billingDbContext.Customers
                .AsNoTracking()
                .Where(x => x.Active == 'Y')
                .OrderBy(x => x.Id);

            var total = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, total);
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _billingDbContext.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Active == 'Y');
        }

        public async Task<int> Create(Customer customer)
        {
            customer.CreatedAt ??= DateTime.Now;
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
