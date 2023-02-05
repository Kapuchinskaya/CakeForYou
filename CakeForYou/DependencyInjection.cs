using CakeForYou.Common.Errors;
using CakeForYou.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CakeForYou
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, CakeForYouProblemDetailsFactory>();
            services.AddMappings();

            return services;
        }
    }
}