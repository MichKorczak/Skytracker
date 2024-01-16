using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Skytracker.Infrastructure.Mappings;

public static class Extensions
{
    public static IServiceCollection AddMappings(this IServiceCollection services, Assembly assembly)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(assembly);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
