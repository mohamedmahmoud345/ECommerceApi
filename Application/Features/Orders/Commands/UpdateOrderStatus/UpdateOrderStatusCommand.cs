using System;
using Core.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusCommand : IRequest<bool>
    {
        public UpdateOrderStatusCommand(Guid orderId, OrderStatus orderStatus)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
        }

        public Guid OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
