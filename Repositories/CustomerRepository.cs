using MyApiProject.Data;
using MyApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApiProject.Repositories
{
    public class CustomerRepository : BaseRepository,ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            Log("Fetching all customers.");
            return await _context.Customers.Include(c => c.Product).ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            Log($"Fetching customer by ID: {id}");
            return await _context.Customers.Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            Log("Adding a new customer.");
            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public async Task UpdateAsync(Customer customer)
        {
            Log($"Updating customer with ID: {customer.Id}");
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Log($"Deleting customer with ID: {id}");
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        // 👇 Abstract method implementation
        public override Task<string> GetEntityNameAsync()
        {
            return Task.FromResult("Customer");
        }
    }
}
