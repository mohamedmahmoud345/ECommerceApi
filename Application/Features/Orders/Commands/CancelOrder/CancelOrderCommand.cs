using System;
using MediatR;

namespace Application.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public CancelOrderCommand(Guid id)
        {
            OrderId = id;
        }
    }
}
