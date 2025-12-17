using BillingApp.Models;

namespace BillingApp.Repository
{
    public interface IProductRepository
    {
        Task<int> Create(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(int id);
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
    }
}
