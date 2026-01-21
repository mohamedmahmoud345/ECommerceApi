using System;
using MediatR;

namespace Application.Features.Cart.Commands.UpdateItemQuantity
{
    public class UpdateItemQuantityCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public UpdateItemQuantityCommand(Guid customerId, Guid itemId, int quantity)
        {
            CustomerId = customerId;
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}
