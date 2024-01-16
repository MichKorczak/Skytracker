using BuilderPart.Domain;
using Skytracker.Domain.ValueObjects;

namespace Skytracker.Domain.Entities;

public class Flight : IAggregateRoot
{
    private Flight(FlightId flightId, string destination, string departurePoint)
    {
        FlightId = flightId;
        Destination = destination;
        DeparturePoint = departurePoint;
    }

    public FlightId FlightId { get; private set; }

    public string Destination { get; private set; }

    public string DeparturePoint { get; private set; }

    public NumberOfTravelers NumberOfTravelers { get; private set; }

    public CabinClass CabinClass { get; private set; }
}
