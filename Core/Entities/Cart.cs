using System.Net.Quic;

namespace Core.Entities
{
    public class Cart
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        private List<CartItem> _items = new List<CartItem>();

        public int Quantity => _items.Sum(x => x.Quantity);
        public decimal TotalAmount => _items.Sum(x => x.Quantity * x.Product.Price);
        public Cart(Guid customerId)
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
            CustomerId = customerId;
        }
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        public void AddItem(Product product , int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if(quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            var item = _items.FirstOrDefault(x => x.Product.Id == product.Id);
            if(item != null)
            {
                item.UpdateQuantity(item.Quantity + quantity);
            }
            else
            {                
                _items.Add(new CartItem(product.Id, quantity));
            }
        }
        public void RemoveItem(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            var item = _items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (item != null)
                _items.Remove(item);
        }
        public void ClearCart() => _items.Clear();

    }
}
