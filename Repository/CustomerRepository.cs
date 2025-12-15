using BillingApp.Context;
using BillingApp.DTOs;
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

        public Task<int> Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _billingDbContext.Customers
                                 .AsNoTracking()
             .ToListAsync();
        }
        public Task<Customer?> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
