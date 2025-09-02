using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

using System.Reflection;
using Clothing.Application.Behaviors;


namespace Clothing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            //services.AddTransient<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
