using Core.Enums;

namespace Core.Entities
{
    public class Order
    {
        public Order(DateTime date, OrderStatus status, Customer customer)
        {
            Id = Guid.NewGuid();
            Date = date;
            Status = status;
            Customer = customer;
        }

        public Guid Id { get; private set; }
        private List<OrderItem> _items = new();
        public decimal TotalAmount => _items.Sum(x => x.TotalAmount());
        public DateTime Date { get; private set; }  
        public OrderStatus Status { get; private set; }
        public Customer Customer { get; private set; }
        public Admin? Admin { get; private set; }
        
        public IReadOnlyCollection<OrderItem> Items => _items; 
        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var item = new OrderItem(Id, productId, quantity, unitPrice);
            _items.Add(item);
        }
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
        
    }
}
