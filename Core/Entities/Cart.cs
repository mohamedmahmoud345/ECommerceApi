namespace Core.Entities
{
    public class Cart
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        private List<CartItem> _items = new List<CartItem>();
        public DateTime CreatedAt { get; private set; }
        public int Quantity => _items.Sum(x => x.Quantity);
        public decimal TotalAmount => _items.Sum(x => x.Quantity * x.Product.Price);
        public Cart(Guid customerId)
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
            CustomerId = customerId;
            CreatedAt = DateTime.UtcNow;
        }
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        public void AddItem(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive");
            if (_items.Count >= 100)
                throw new InvalidOperationException("Your cart has reached the maximum limit of 100 items");
            var item = _items.FirstOrDefault(x => x.ProductId == product.Id);

            var requestedQuantity = item != null ? item.Quantity + quantity : quantity;
            if (requestedQuantity > product.StockQuantity)
                throw new InvalidOperationException($"Cannot add {quantity} items. Only {product.StockQuantity} available in stock.");

            if (item != null)
            {
                item.UpdateQuantity(item.Quantity + quantity);
            }
            else
            {
                _items.Add(new CartItem(Id, product, quantity));
            }
        }
        public void RemoveItem(Guid itemId)
        {
            var item = _items.FirstOrDefault(x => x.Id == itemId);
            if (item != null)
                _items.Remove(item);
        }
        public void ClearCart() => _items.Clear();

    }
}
