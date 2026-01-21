using System;
using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Cart.Commands.UpdateItemQuantity
{
    public class UpdateItemQuantityHandler : IRequestHandler<UpdateItemQuantityCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateItemQuantityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId);
            if (cart == null)
                return false;

            var item = await _unitOfWork.Carts.GetItemByIdAsync(request.ItemId);
            if (item == null)
                return false;

            item.UpdateQuantity(request.Quantity);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
