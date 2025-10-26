using Application.Dto.CartDto;
using Core.Entities;

namespace Application.Interfaces.IServices
{
    public interface ICartService
    {
        Task<CartDto?> GetByCustomerIdAsync(Guid customerId);
        Task<bool> HasActiveCartAsync(Guid customerId);
        Task<CartDto> GetByIdAsync(Guid id);
        Task Update(CartDto entity);
        Task AddAsync(CartDto entity);
        Task DeleteAsync(Guid id);
    }
}
