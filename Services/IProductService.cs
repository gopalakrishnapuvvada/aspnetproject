using MyApiProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
    }
}
