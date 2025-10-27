
using Application.Interfaces.IServices;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependecies
{
    public static class ServicesDependecies 
    {
        public static IServiceCollection AddServicesDependecies
            (this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
