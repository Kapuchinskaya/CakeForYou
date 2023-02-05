using System.Reflection;
using CakeForYou.Application.Authentication.Commands.Register;
using CakeForYou.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace CakeForYou.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services
                .AddScoped(
                    typeof(IPipelineBehavior<,>),
                    typeof(ValidationBehavior<,>));

            // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}