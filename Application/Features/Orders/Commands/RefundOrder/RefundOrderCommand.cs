using System;
using Core.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.RefundOrder
{
    public class RefundOrderCommand : IRequest<bool>
    {
        public RefundOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
    }
}
