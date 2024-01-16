using Microsoft.Extensions.DependencyInjection;
using Skytracker.Application;
using MediatR;
using Skytracker.Infrastructure.Validation;
using BuilderPart.Application.Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Skytracker.Domain.Repositories;
using Skytracker.Infrastructure.Repositories;
using Skytracker.Infrastructure.Mappings;

namespace Skytracker.Infrastructure;

public static class DependencyInjectionInfrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var test = SkytrackerApplicationAssembly.GetAssembly;
        services.AddMediatR(test);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddScoped<IBus, MediatRBus>();

        using var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();
        var dbConnectionString = configuration["ConnectionString"];

        services.AddDbContext<SkytrackerDbContext>(d => d.UseSqlServer(dbConnectionString));
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IUnitOfWork, FlightRepository>();

        services.AddMappings(SkytrackerInfrastructureAssembly.GetAssembly);

        return services;
    }

}
