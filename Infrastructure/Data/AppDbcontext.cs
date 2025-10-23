using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Admin> Admins { get; set; }


        public AppDbcontext()
        {            
        }
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }
    }
}
