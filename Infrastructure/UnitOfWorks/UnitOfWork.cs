
using Application.Interfaces.IRepositories;
using Application.IUnitOfWorks;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IProductRepository products, IOrderRepository orders, ICartRepository carts, ICustomerRepository customers, ICategoryRepository categories, IReviewRepository reviews, IPaymentRepository payments)
        {
            _context = context;
            Products = new ProductRepository(context);
            Orders = new OrderRepository(context);
            Carts = new CartRepository(context);
            Customers = new CustomerRepository(context);
            Categories = new CategoryRepository(context);
            Reviews = new ReviewRepository(context);
            Payments = new PaymentRepository(context);
        }

        public IProductRepository Products { get; }

        public IOrderRepository Orders {get;}

        public ICartRepository Carts {get;}

        public ICustomerRepository Customers {get;}

        public ICategoryRepository Categories {get;}

        public IReviewRepository Reviews {get;}

        public IPaymentRepository Payments {get;}

        

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
