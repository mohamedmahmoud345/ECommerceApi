namespace Core.Entities
{
    public class Product
    {
        public Product(string name, string description, string imageUrl, decimal price, int stockQuantity, Guid categoryId, Guid? adminId)
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(nameof(name));
            if(price < 0)
                throw new ArgumentOutOfRangeException(nameof(price));
            if(stockQuantity < 0)
                throw new ArgumentOutOfRangeException(nameof(stockQuantity));
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
            AdminId = adminId;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Guid? AdminId { get; private set; }
        public Admin Admin { get; private set; }

        public void UpdateStockQuantity(int quantity)
        {
            if(quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            StockQuantity  = quantity;
        }
        public bool IsInStock() => StockQuantity > 0;
        public void UpdatePrice(decimal newPrice)
        {
            if(newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice));
            Price = newPrice;
        }
        public void Rename(string name)
        {
            if(!string.IsNullOrWhiteSpace(name))    
                throw new ArgumentException("Name is required", nameof(name));
            Name = name;
        }
        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Description is required", nameof(description));
            Description = description;
        }
        public void ChangePhoto(string imageUrl)
        {
            if(string.IsNullOrWhiteSpace(imageUrl))
                throw new ArgumentException(nameof(imageUrl));
            ImageUrl = imageUrl;
        }
    }
}
