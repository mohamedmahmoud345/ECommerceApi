
namespace Application.Features.Orders.Common
{
    public class OrderItemResponse
    {
        public Guid Id { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
