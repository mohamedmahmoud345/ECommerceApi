
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }
        public async Task<Customer> AddAsync(Customer entity)
        {
            var customer = await _context.Customers.AddAsync(entity);
            return customer.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
                _context.Customers.Remove(customer);
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _context.Customers.AsNoTracking().SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Customer> GetByIdAsync(Guid id, bool asNoTracking = false)
        {
            var query = _context.Customers
                .Include(x => x.Cart)
                .AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }
    }
}
