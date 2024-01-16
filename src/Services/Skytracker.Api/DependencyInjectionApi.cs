using Skytracker.Api.Utilities;
using Skytracker.Infrastructure.Mappings;

namespace Skytracker.Api;

public static class DependencyInjectionApi
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<IProblemFactory, ProblemFactory>();
        services.AddMappings(SkytrackerApiAssembly.GetAssembly);

        return services;
    }
}
