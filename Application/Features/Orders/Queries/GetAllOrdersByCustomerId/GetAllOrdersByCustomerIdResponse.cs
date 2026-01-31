using Application.Features.Orders.Common;
using Core.Enums;

namespace Application.Features.Orders.Queries.GetAllOrdersByCustomerId
{
    public class GetAllOrdersByCustomerIdResponse
    {
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public int NumberOfOrders { get; set; }
        public List<Orders> OrderList { get; set; } = new();

        public class Orders
        {
            public Guid Id { get; set; }
            public decimal TotalAmount { get; set; }
            public OrderStatus Status { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
