using BuilderPart.Domain;
using Skytracker.Domain.Exceptions;

namespace Skytracker.Domain.ValueObjects;

public class NumberOfTravelers : ValueObject
{
    public NumberOfTravelers(short value)
    {
        Value = value;
        CheckInvariants();
    }

    public short Value { get; private set; }

    public NumberOfTravelers Create(short value) => new(value);

    private void CheckInvariants()
    {
        if (Value < 1)
        {
            throw new InvalidNumberOfTravelersException(Value);
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}