using Data.Repositories;
using Domain.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAnexoRepository, AnexoRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();

            return services;
        }
    }
}
