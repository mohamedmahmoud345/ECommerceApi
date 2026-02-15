
using Application.Interfaces.IRepositories;

namespace Application.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        ICartRepository Carts { get; }
        ICustomerRepository Customers { get; }
        ICategoryRepository Categories { get; }
        IReviewRepository Reviews { get; }
        IPaymentRepository Payments { get; }

        Task<int> SaveChangesAsync();
        Task ExecuteInTransactionAsync(Func<Task> action, CancellationToken cancellationToken = default);
    }
}
