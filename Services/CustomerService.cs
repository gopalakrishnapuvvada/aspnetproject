using MyApiProject.Models;
using MyApiProject.Repositories;

namespace MyApiProject.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Customer>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Customer?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Customer> CreateAsync(Customer customer) => _repo.AddAsync(customer);
        public Task UpdateAsync(Customer customer) => _repo.UpdateAsync(customer);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
