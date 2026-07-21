

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataSeeder
    {
        public static async Task SeedProductsAsync(AppDbContext context)
        {
            if (await context.Products.AnyAsync())
                return;

            if (!await context.Categories.AnyAsync())
            {
                var categories = new List<Category>
            {
                new Category("Electronics", "Devices, gadgets, and electronic accessories"),
                new Category("Accessories", "Peripherals and add-ons for everyday use")
            };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            var electronics = await context.Categories.FirstAsync(c => c.Name == "Electronics");
            var accessories = await context.Categories.FirstAsync(c => c.Name == "Accessories");

            var products = new List<Product>
        {
            new Product("Wireless Mouse", "Ergonomic wireless mouse with USB receiver", "https://placehold.co/400x400?text=Mouse", 25.99m, 50, accessories.Id),
            new Product("Mechanical Keyboard", "RGB backlit mechanical keyboard, blue switches", "https://placehold.co/400x400?text=Keyboard", 89.99m, 30, accessories.Id),
            new Product("USB-C Hub", "7-in-1 USB-C hub with HDMI and card reader", "https://placehold.co/400x400?text=USB-Hub", 34.50m, 100, accessories.Id),
            new Product("Noise Cancelling Headphones", "Over-ear wireless headphones with ANC", "https://placehold.co/400x400?text=Headphones", 149.99m, 20, electronics.Id),
            new Product("27\" 4K Monitor", "IPS 4K UHD monitor, 60Hz", "https://placehold.co/400x400?text=Monitor", 299.00m, 15, electronics.Id),
            new Product("Laptop Stand", "Adjustable aluminum laptop stand", "https://placehold.co/400x400?text=Stand", 19.99m, 75, accessories.Id),
        };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}