using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Data;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyAppInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IMyAppContext, MyAppContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString(name: "Default")));

            return services;
        }
    }
}
