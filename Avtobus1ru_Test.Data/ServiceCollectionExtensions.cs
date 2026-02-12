using Avtobus1ru_Test.Data.Interfaces;
using Avtobus1ru_Test.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avtobus1ru_Test.Data
{
    public static class ServiceCollectionExtensions
    {
        private static IServiceCollection AddMariaDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<DataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            return services;
        }


        public static IServiceCollection AddEfRepository(this IServiceCollection services, string connectionString)
        {
            services.AddMariaDbContext(connectionString);

            services.AddScoped<ILinkRepository, LinkRepository>();

            return services;
        }
    }
}
