using BillingApp.Models;
using BillingApp.Context;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly BillingDbContext _billingDbContext;
        public ProductRepository(BillingDbContext billingDbContext)
        {
            _billingDbContext = billingDbContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _billingDbContext.Products
                .AsNoTracking()
                .Where(x => x.Active == 'Y')
                .ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _billingDbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Active == 'Y');
        }

        public async Task<int> Create(Product product)
        {
            product.Active = 'Y';

            _billingDbContext.Products.Add(product);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Product product)
        {
            _billingDbContext.Products.Update(product);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var product = await _billingDbContext.Products.FindAsync(id);
            if (product == null) return 0;

            product.Active = 'N';
            return await _billingDbContext.SaveChangesAsync();
        }
    }
}
