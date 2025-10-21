
namespace Core.Entities
{
    public class CartItem
    {
        public Guid Id { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public DateTime DateAdded { get; private set; }


        public CartItem(Product product, int quantity)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity = quantity;
            DateAdded = DateTime.UtcNow;
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
    }
}
