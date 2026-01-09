using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Cart.Commands.DeleteItemFromCart
{
    public class DeleteItemFromCartHandle
        : IRequestHandler<DeleteItemFromCartCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemFromCartHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteItemFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(request.CustomerId);
            if (cart is null)
                return false;

            var item = cart.Items.FirstOrDefault(x => x.Id == request.ItemId);
            if (item is null)
                return false;

            cart.RemoveItem(request.ItemId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
