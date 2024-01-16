using BuilderPart.Domain;

namespace Skytracker.Domain.ValueObjects;

public class FlightId : ValueObject
{
    private FlightId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static FlightId Create(Guid id) => new(id);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
