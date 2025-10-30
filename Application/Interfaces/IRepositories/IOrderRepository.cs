
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<Order>?> GetByCustomerIdAsync(Guid customerId); 
        Task<Order> GetByIdAsync(Guid id);
        Task Update(Order entity);
        Task<Order> AddAsync(Order entity);
        Task DeleteAsync(Guid id);
    }
}
