using BillingApp.Models;

namespace BillingApp.Repository
{
    public interface ICustomerRepository
    {
        Task<int> Create(Customer customer);
        Task<int> Update(Customer customer);
        Task<int> Delete(int id);
        Task<Customer?> GetCustomerById(int id);
        Task<List<Customer>> GetAllCustomers();
        Task<(List<Customer> Items, int TotalCount)> GetAllCustomersPaged(int page, int pageSize);
    }

}
