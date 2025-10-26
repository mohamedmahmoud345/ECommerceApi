
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetByCustomerIdAsync(Guid customerId);
        Task<bool> HasActiveCartAsync(Guid customerId);
        Task<Cart> GetByIdAsync(Guid id);
        void Update(Cart entity);
        Task AddAsync(Cart entity);
        Task DeleteAsync(Guid id);
    }
}
