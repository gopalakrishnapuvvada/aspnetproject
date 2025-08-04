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
    }
}
