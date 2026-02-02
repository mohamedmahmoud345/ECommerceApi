using System;
using Application.IUnitOfWorks;
using Core.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, bool>

    {
        private readonly IUnitOfWork _unitOfWork;
        public CancelOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);

            if (order is null || order.Status != OrderStatus.Pending)
                return false;

            order.UpdateStatus(OrderStatus.Cancelled);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
