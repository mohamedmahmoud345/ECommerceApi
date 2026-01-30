using Application.Features.Orders.Common;

namespace Application.Features.Orders.Queries.GetAllOrdersByCustomerId
{
    public class GetAllOrdersByCustomerIdResponse
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public int NumberOfOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; } = new();
    }
}
