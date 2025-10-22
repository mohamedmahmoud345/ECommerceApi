
namespace Core.Entities
{
    public class CartItem
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime DateAdded { get; private set; }
        public Guid CartId { get; private set; }
        public Cart Cart { get; private set; }

        private CartItem() { }

        public CartItem(Guid cartId,Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive");
            Id = Guid.NewGuid();
            CartId = cartId;
            Product = product;
            ProductId = product.Id;
            Quantity = quantity;
            DateAdded = DateTime.UtcNow;
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity must be positive");
            Quantity = newQuantity;
        }
    }
}
