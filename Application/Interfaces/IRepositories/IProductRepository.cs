
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>?> GetByCategoryIdAsync(Guid id);
        Task<List<Product>?> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id, bool asNoTracking = false);
        Task Update(Product entity);
        Task<Product> AddAsync(Product entity);
        Task DeleteAsync(Guid id);
    }
}
