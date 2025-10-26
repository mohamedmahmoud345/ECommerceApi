
using Application.Dto.CartDto;
using Application.Interfaces.IServices;
using Application.IUnitOfWorks;

namespace Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(CartDto entity)
        {
            if(entity == null) 
                throw new ArgumentNullException(nameof(entity));

            await _unitOfWork.Carts.AddAsync(entity.FromDto());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.Carts.DeleteAsync(id);
        }

        public async Task<CartDto?> GetByCustomerIdAsync(Guid customerId)
        {
            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(customerId);
            return cart.ToDto();
        }

        public async Task<CartDto> GetByIdAsync(Guid id)
        {
            var cart = await _unitOfWork.Carts.GetByIdAsync(id);
            return cart.ToDto();
        }

        public async Task<bool> HasActiveCartAsync(Guid customerId)
        {
            return await _unitOfWork.Carts.HasActiveCartAsync(customerId);
        }

        public async Task Update(CartDto entity)
        {
            _unitOfWork.Carts.Update(entity.FromDto());
        }
    }
}
