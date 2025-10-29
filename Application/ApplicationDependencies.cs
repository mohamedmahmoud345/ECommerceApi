
using Application.Mapping.Customers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationDependencies 
    {
        public static IServiceCollection AddApplicationDependencies
            (this IServiceCollection services)
        {
            // register mediator
            services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // register automapper
            services.AddAutoMapper(cfg => cfg.AddProfile(typeof(CustomerProfile)));
            return services;
        }
    }
}
