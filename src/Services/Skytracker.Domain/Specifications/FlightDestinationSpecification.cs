using BuilderPart.Domain.Specification;
using Skytracker.Domain.Entities;
using System.Linq.Expressions;

namespace Skytracker.Domain.Specifications;

public class FlightDestinationSpecification : Specification<Flight>
{
    private readonly string _destination;

    public FlightDestinationSpecification(string to)
    {
        _destination = to;
    }

    public override Expression<Func<Flight, bool>> ToExpression()
    {
        return x => x.Destination == _destination;
    }
}
