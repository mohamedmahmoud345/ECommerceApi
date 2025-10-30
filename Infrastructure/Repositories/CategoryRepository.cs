
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddAsync(Category entity)
        {
            var category = await _context.Categories.AddAsync(entity);
            return category.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category != null)
                _context.Categories.Remove(category);
        }

        public async Task<List<Category>?> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task Update(Category entity)
        {
            _context.Categories.Update(entity);
        }
    }
}
