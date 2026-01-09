using System;
using Core.Entities;
using MediatR;

namespace Application.Features.Cart.Commands.DeleteItemFromCart
{
    public class DeleteItemFromCartCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }
        public Guid ItemId { get; set; }

        public DeleteItemFromCartCommand(Guid customerId, Guid itemId)
        {
            CustomerId = customerId;
            ItemId = itemId;
        }
    }
}
