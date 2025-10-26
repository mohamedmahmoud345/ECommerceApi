

using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
        }

        public async Task<List<Product>?> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>?> GetByCategoryIdAsync(Guid id)
        {
            return await _context.Products.Where(x => x.CategoryId == id).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(Product entity)
        {
            var product = await _context.Products.FindAsync(entity.Id);
            _context.Products.Update(entity);
        }
    }
}
