
using Application.Mapping.Customers;
using AutoMapper;
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
            services.AddAutoMapper(typeof(CustomerProfile).Assembly);
            return services;
        }
    }
}
