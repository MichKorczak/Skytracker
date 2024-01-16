using BuilderPart.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using Skytracker.Domain.Entities;
using Skytracker.Domain.Repositories;

namespace Skytracker.Infrastructure.Repositories;

public class FlightRepository : IFlightRepository, IUnitOfWork
{
    private readonly SkytrackerDbContext _skytrackerDbContext;

    public FlightRepository(SkytrackerDbContext skytrackerDbContext)
    {
        _skytrackerDbContext = skytrackerDbContext;
    }

    public async Task<IEnumerable<Flight>> GetFlightsAsync(Specification<Flight> specification) 
        => await _skytrackerDbContext.Flights.Where(specification.ToExpression()).ToArrayAsync();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        => await _skytrackerDbContext.SaveChangesAsync(cancellationToken);
}
