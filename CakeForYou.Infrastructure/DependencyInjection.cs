using System.Text;
using CakeForYou.Application.Common.Interfaces.Authentication;
using CakeForYou.Application.Common.Interfaces.Persistence;
using CakeForYou.Application.Common.Interfaces.Services;
using CakeForYou.Infrastructure.Authentication;
using CakeForYou.Infrastructure.Persistence;
using CakeForYou.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CakeForYou.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddAuth(configuration).AddPersistence();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            AddPersistence(services);

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<CfyDbContext>(options =>
                options.UseSqlServer(
                    "Server=DESKTOP-FQ90AIT\\MSSQLSERVERCFY;Database=CakeForYou;User Id=SA;Password=CakeForYou2018!!;TrustServerCertificate=True;"));
            
            services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<ICakeRepository, CakeRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}