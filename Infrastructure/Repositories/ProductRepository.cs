

using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            if (product == null)
                throw new ArgumentNullException(nameof(id));

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
            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
                throw new ArgumentNullException(nameof(Product));
            return Product;
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }
    }
}
