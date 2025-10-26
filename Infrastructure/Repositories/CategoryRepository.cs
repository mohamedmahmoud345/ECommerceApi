
using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null) 
                throw new ArgumentNullException(nameof(category));
            _context.Categories.Remove(category);
        }

        public async Task<List<Category>?> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null )
                throw new ArgumentNullException(nameof(category));

            return category;
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }
    }
}
