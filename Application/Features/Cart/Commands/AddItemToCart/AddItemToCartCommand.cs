using MediatR;

namespace Application.Features.Cart.Commands.AddItemToCart
{
    public class AddItemToCartCommand : IRequest<AddItemToCartResponse>
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}