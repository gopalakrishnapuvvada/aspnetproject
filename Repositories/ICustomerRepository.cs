using MyApiProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);
    }
}
