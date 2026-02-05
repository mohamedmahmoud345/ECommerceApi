using Core.Enums;

namespace Core.Entities
{
    public class Order
    {
        public Order(OrderStatus status, Guid customerId)
        {
            Id = Guid.NewGuid();
            Status = status;
            CustomerId = customerId;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        private List<OrderItem> _items = new();
        public decimal TotalAmount => _items.Sum(x => x.TotalAmount());
        public OrderStatus Status { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var item = new OrderItem(Id, productId, quantity, unitPrice);
            _items.Add(item);
        }
        public void UpdateStatus(OrderStatus newStatus)
        {
            if (Status == OrderStatus.Delivered && newStatus == OrderStatus.Pending)
                throw new InvalidOperationException();
            if (Status == OrderStatus.Cancelled && newStatus == OrderStatus.Shipped)
                throw new InvalidOperationException();
            if (Status == OrderStatus.Pending && newStatus == OrderStatus.Delivered)
                throw new InvalidOperationException();
            if (Status == OrderStatus.Delivered && newStatus == OrderStatus.Paid)
                throw new InvalidOperationException();
            if (Status == OrderStatus.Paid && newStatus == OrderStatus.Delivered)
                throw new InvalidOperationException();

            Status = newStatus;
        }

    }
}
