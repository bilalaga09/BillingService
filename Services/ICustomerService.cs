using BillingApp.Models;

namespace BillingApp.Services
{
    public interface ICustomerService
    {
        Task<int> Create(Customer customer);
        Task<int> Update(Customer customer);
        Task<int> Delete(int id);
        Task<Customer?> GetCustomerById(int id);
        //Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetAllCustomers();
    }
}
