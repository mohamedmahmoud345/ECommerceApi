using System;
using MediatR;

namespace Application.Features.Cart.Commands.ClearCart
{
    public class ClearCartCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }
        public ClearCartCommand(Guid id)
        {
            CustomerId = id;
        }
    }
}
