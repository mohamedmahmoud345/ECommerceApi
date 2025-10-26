
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByCustomerIdAsync(Guid cusomterId);
        Task<Payment> GetByIdAsync(Guid id);
        Task Update(Payment entity);
        Task AddAsync(Payment entity);
        Task DeleteAsync(Guid id);
    }
}
