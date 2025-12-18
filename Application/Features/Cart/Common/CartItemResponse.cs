namespace Application.Features.Cart.Common
{
    public class CartItemResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal SubTotal { get; set; }
    }
}