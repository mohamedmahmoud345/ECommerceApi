using Application.Features.Cart.Common;

namespace Application.Features.Cart.Commands.AddItemToCart
{
    public class AddItemToCartResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }

        public int TotalItems { get; set; }
        public int TotalAmount { get; set; }
        public List<CartItemResponse> Items { get; set; } = new();
    }
}
