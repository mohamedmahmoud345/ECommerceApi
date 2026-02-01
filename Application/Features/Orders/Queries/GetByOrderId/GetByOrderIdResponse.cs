using System;
using Application.Features.Orders.Common;
using Core.Enums;

namespace Application.Features.Orders.Queries.GetByOrderId
{
    public class GetByOrderIdResponse
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; } = new();
    }
}
