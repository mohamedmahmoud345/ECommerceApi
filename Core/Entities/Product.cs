using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public Product(string name, string description, string imageUrl, decimal price, int stockQuantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public Admin Admin { get; private set; }
        public Category Category { get; private set; }

        public void UpdateStockQuantity(int quantity)
        {
            StockQuantity  = quantity;
        }
        public bool IsInStock() => StockQuantity > 0;
        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }
    }
}
