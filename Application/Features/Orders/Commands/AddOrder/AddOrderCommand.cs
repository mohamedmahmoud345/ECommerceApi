using Core.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<AddOrderResponse>
    {
        public Guid CustomerId { get; set; }

        public AddOrderCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
