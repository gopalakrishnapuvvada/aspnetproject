using MyApiProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
