
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
        public async Task AddAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer == null)
                throw new ArgumentNullException(nameof(customer));

            _context.Customers.Remove(customer);
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Email == email);
            if(customer == null)
                throw new ArgumentNullException(nameof(customer));
            return customer;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer == null)
                throw new ArgumentNullException(nameof(customer));

            return customer;
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }
    }
}
