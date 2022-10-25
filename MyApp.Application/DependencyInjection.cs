using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Data;

namespace MyApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyAppApplication(this IServiceCollection service)
        {
            service.AddMediatR(typeof(IMyAppContext));

            return service;
        }
    }
}
