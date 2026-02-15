using Application.Interfaces.IRepositories;
using Application.Interfaces.Services;
using Application.Interfaces.Services.GenerateToken;
using Application.IUnitOfWorks;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependecies
{
    public static class RepositoriesDependencies
    {
        public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IFileStorageService, LocalFileStorageService>();
            services.AddScoped<IPaymentService, SimulatedPaymentService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenerateJwtToken, GenerateJwtToken>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
