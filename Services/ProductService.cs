using MyApiProject.Models;
using MyApiProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _repo.AddAsync(product);
        }
        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _repo.GetByIdAsync(id);
            if (existingProduct == null) return null;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _repo.UpdateAsync(existingProduct);

            return existingProduct;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _repo.DeleteProductAsync(id);
        }
        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            return await _repo.SoftDeleteAsync(id);
        }

    }
}
