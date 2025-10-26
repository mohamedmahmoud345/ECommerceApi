

using Application.Interfaces.IRepositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependecies
{
    public static class RepositoriesDependecies
    {
        public static IServiceCollection AddRepositoriesDependecies(this IServiceCollection services)
        {
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository , CategoryRepository>();
            services.AddScoped<ICustomerRepository , CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository , ProductRepository>();   
            services.AddScoped<IReviewRepository , ReviewRepository>();

            return services;
        }
    }
}
