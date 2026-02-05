using System;
using Application.IUnitOfWorks;
using Core.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.RefundOrder
{
    public class RefundOrderHandler : IRequestHandler<RefundOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RefundOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RefundOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
            if (order is null)
                throw new NullReferenceException();

            var payment = await _unitOfWork.Payments.GetByOrderId(order.Id);
            if (payment is null)
                throw new NullReferenceException();

            if (payment.Status != PaymentStatus.Completed)
                return false;

            if (order.Status != OrderStatus.Paid && order.Status != OrderStatus.Shipped)
                return false;


            order.UpdateStatus(OrderStatus.Cancelled);
            payment.UpdateStatus(PaymentStatus.Refunded);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
