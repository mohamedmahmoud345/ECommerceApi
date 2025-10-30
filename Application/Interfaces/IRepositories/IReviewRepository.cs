
using Core.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IReviewRepository
    {
        Task<List<Review>?> GetByCustomerIdAsync(Guid customerId);
        Task<List<Review>?> GetByProductIdAsync(Guid productId);
        Task<Review> GetByIdAsync(Guid id);
        Task Update(Review entity);
        Task<Review> AddAsync(Review entity);
        Task DeleteAsync(Guid id);
    }
}
