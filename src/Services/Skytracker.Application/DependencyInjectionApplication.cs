using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skytracker.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(SkytrackerApplicationAssembly.GetAssembly);

            return services;
        }
    }
}
