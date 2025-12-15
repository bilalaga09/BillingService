using BillingApp.DTOs;
using BillingApp.Models;
using BillingApp.Repository;

namespace BillingApp.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<int> Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();

            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Email = c.Email,
                Address = c.Address,
                GSTNumber = c.GSTNumber
            }).ToList();
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
