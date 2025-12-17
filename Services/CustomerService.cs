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

        public async Task<int> Create(Customer customer)
        {
            // Ensure server-controlled fields are set and client cannot override them
            customer.Id = 0;
            customer.Active = 'Y';
            customer.CreatedAt ??= DateTime.UtcNow;

            return await _customerRepository.Create(customer);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();

            return customers;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null) return null;

            return customer;
        }

        public async Task<int> Update(Customer updatedCustomer)
        {
            var existingCustomer = await _customerRepository.GetCustomerById(updatedCustomer.Id);
            if (existingCustomer == null) return 0;

            return await _customerRepository.Update(updatedCustomer);
        }

        public async Task<int> Delete(int id)
        {
            return await _customerRepository.Delete(id);
        }
    }
}
