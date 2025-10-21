using System.Net.Quic;

namespace Core.Entities
{
    public class Cart
    {
        public Guid Id { get; private set; }
        public int Quantity { get; private set; }
        public TimeSpan Date { get; private set; }

        public Customer Customer { get; private set; }
        private List<CartItem> _items = new List<CartItem>();

        public Cart(Guid id, int quantity, TimeSpan date, 
            Customer customer)
        {
            Id = id;
            Quantity = quantity;
            Date = date;
            Customer = customer;
        }
        public IReadOnlyCollection<CartItem> Items => Items;

        public void AddItem(Product product , int quantity)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == product.Id);
            if(item != null)
            {
                item.UpdateQuantity(quantity);
            }
            else
            {                
                _items.Add(new CartItem(product, quantity));
            }
        }
        public void RemoveItem(Product product)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (item != null)
                _items.Remove(item);
        }
        public void ClearCart() => _items.Clear();

    }
}
