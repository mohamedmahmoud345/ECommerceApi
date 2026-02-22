using Application.Behaviors;
using Application.Mapping.Customers;
using FluentValidation;
using MediatR;
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

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // register validation pipeline so validators run before handlers
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviors<,>));

            return services;
        }
    }
}
