namespace Core.Entities
{
    public class OrderItem
    {
        public OrderItem(Guid orderId, Guid productId, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            Quantity = quantity;
            if (UnitPrice < 0)
                throw new ArgumentException(nameof(UnitPrice));
            UnitPrice = unitPrice;
        }

        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public decimal TotalAmount() => Quantity * UnitPrice;
    }
}
