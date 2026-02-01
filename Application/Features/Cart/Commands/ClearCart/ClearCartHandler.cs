using System;
using Application.IUnitOfWorks;
using MediatR;

namespace Application.Features.Cart.Commands.ClearCart
{
    public class ClearCartHandler : IRequestHandler<ClearCartCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClearCartHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return false;

            var cart = await _unitOfWork.Carts.GetByCustomerIdAsync(customer.Id);
            if (cart is null || !cart.Items.Any())
                return false;

            cart.ClearCart();
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
