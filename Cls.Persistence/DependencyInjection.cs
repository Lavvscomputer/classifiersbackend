using Classifiers.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Classifiers.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration["DbConnection"];
            services.AddDbContext<ClassifiersDbContext>(options => 
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    npgsqlOptions.CommandTimeout(30); // Таймаут команды в секундах
                    npgsqlOptions.EnableRetryOnFailure(5); // Повторные попытки подключения
                });
            });
            services.AddScoped<IClassifiersDbContext, ClassifiersDbContext>();
            return services;
        }
    }
}
