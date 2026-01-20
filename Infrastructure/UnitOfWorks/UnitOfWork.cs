
using Application.Interfaces.IRepositories;
using Application.IUnitOfWorks;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IProductRepository products, IOrderRepository orders, ICartRepository carts, ICustomerRepository customers, ICategoryRepository categories, IReviewRepository reviews, IPaymentRepository payments)
        {
            _context = context;
            Products = products;
            Orders = orders;
            Carts = carts;
            Customers = customers;
            Categories = categories;
            Reviews = reviews;
            Payments = payments;
        }

        public IProductRepository Products { get; }

        public IOrderRepository Orders { get; }

        public ICartRepository Carts { get; }

        public ICustomerRepository Customers { get; }

        public ICategoryRepository Categories { get; }

        public IReviewRepository Reviews { get; }

        public IPaymentRepository Payments { get; }



        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
