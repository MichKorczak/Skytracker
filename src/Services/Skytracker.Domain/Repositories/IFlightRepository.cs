using BuilderPart.Domain.Specification;
using Skytracker.Domain.Entities;

namespace Skytracker.Domain.Repositories;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetFlightsAsync(Specification<Flight> specification);
}
