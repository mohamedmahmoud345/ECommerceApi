using Application.Features.Orders.Common;
using Core.Enums;

namespace Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderResponse
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; } = new();
    }
}
