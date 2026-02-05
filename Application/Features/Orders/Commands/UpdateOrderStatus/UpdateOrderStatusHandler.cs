using System;
using Application.IUnitOfWorks;
using Core.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOrderStatusHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
            if (order is null)
                throw new NullReferenceException();

            if (order.Status != OrderStatus.Paid && order.Status != OrderStatus.Shipped)
                return false;

            if (order.Status == request.OrderStatus)
                return false;
            
            order.UpdateStatus(request.OrderStatus);
            await _unitOfWork.SaveChangesAsync();
            
            return true;
        }
    }
}
