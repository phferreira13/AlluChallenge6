

using Allu.Challenge6.Configuration;
using Allu.Challenge6.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Allu.Challenge6.Entity.Ioc
{
    public static class Startup
    {
        public static IServiceCollection AddEntityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<Challenge6Context>((serviceProvider, options) =>
            {
                var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
                options.UseNpgsql(appSettings.Connection, o => o.MigrationsAssembly("Allu.Challenge6.Data"));
            });

            services.AddRepositories();

            return services;
        }
    }
}