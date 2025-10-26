
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICategoryRepository 
    {
        Task<List<Category>?> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        void Update(Category entity);
        Task AddAsync(Category entity);
        Task DeleteAsync(Guid id);
    }
}
