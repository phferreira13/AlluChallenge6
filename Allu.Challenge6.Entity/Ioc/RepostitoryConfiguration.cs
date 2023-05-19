using Allu.Challenge6.Domain.Repositories;
using Allu.Challenge6.Entity.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Allu.Challenge6.Entity.Ioc
{
    public static class RepostitoryConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITutorRepository, TutorRepository>();
            return services;
        }
    }
}
