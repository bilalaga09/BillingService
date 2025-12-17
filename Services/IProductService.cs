using BillingApp.Models;

namespace BillingApp.Services
{
    public interface IProductService
    {
        Task<int> Create(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(int id);
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
    }
}
