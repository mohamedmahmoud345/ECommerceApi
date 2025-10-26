
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IProductRepository 
    {
        Task<List<Product>?> GetByCategoryIdAsync(Guid id);
        Task<List<Product>?> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        void Update(Product entity);
        Task AddAsync(Product entity);
        Task DeleteAsync(Guid id);
    }
}
