
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByCustomerIdAsync(Guid cusomterId);
        Task<Payment> GetByOrderId(Guid orderId);
        Task<Payment> GetByIdAsync(Guid id, bool asNoTracking = false);
        Task Update(Payment entity);
        Task<Payment> AddAsync(Payment entity);
        Task DeleteAsync(Guid id);
    }
}
