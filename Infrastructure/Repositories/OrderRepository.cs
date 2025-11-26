
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Order> AddAsync(Order entity)
        {
            var order = await _context.Orders.AddAsync(entity);
            return order.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
                _context.Orders.Remove(order);
        }

        public async Task<List<Order>?> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Orders.AsNoTracking().Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id, bool asNoTracking)
        {
            var query = _context.Orders.AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Order entity)
        {
            _context.Orders.Update(entity);
        }
    }
}
