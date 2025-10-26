
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
        }

        public async Task DeleteAsync(Guid id)
        {
            var cart = _context.Carts.Find(id);
            if(cart == null) 
                throw new ArgumentNullException(nameof(cart));
            _context.Carts.Remove(cart);
        }

        public async Task<Cart?> GetByCustomerIdAsync(Guid customerId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if(cart == null )
                throw new ArgumentNullException(nameof(cart));

            return cart;
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> HasActiveCartAsync(Guid customerId)
        {
            return await _context.Carts.AnyAsync();
        }

        public void Update(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
