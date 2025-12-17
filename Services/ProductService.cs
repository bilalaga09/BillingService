using BillingApp.Models;
using BillingApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BillingApp.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Create(Product product)
        {
            product.Id = 0;
            product.Active = 'Y';

            return await _productRepository.Create(product);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<int> Update(Product updated)
        {
            var existing = await _productRepository.GetProductById(updated.Id);
            if (existing == null) return 0;

            existing.Name = updated.Name;
            existing.CategoryId = updated.CategoryId;
            existing.UnitId = updated.UnitId;
            existing.SKU = updated.SKU;
            existing.Barcode = updated.Barcode;
            existing.HSNCode = updated.HSNCode;
            existing.PurchasePrice = updated.PurchasePrice;
            existing.SalesPrice = updated.SalesPrice;
            existing.TaxRate = updated.TaxRate;
            // Do not overwrite stock fields here unless intended

            return await _productRepository.Update(existing);
        }

        public async Task<int> Delete(int id)
        {
            return await _productRepository.Delete(id);
        }
    }
}
