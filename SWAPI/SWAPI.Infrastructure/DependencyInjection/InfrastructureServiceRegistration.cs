using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http; // 👈 مهم جداً
using SWAPI.Core.Interfaces;
using SWAPI.Infrastructure.Clients;
using System;

namespace SWAPI.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ISwapiClient, SwapiClient>(client =>
            {
                client.BaseAddress = new Uri("https://swapi.dev/api/");
            });

            return services;
        }
    }
}
