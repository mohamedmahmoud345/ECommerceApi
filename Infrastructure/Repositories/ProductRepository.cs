

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
        public async Task<Product> AddAsync(Product entity)
        {
            var prodcut = await _context.Products.AddAsync(entity);
            return prodcut.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
                _context.Products.Remove(product);
        }

        public async Task<List<Product>?> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().Include(x => x.Category).ToListAsync();
        }

        public async Task<List<Product>?> GetByCategoryIdAsync(Guid id)
        {
            return await _context.Products.AsNoTracking().Include(x => x.Category).Where(x => x.CategoryId == id).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.AsNoTracking().Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Product entity)
        {
            _context.Products.Update(entity);
        }
    }
}
