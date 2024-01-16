using BuilderPart.Domain;
using Skytracker.Domain.Enums;
using Skytracker.Domain.Exceptions;

namespace Skytracker.Domain.ValueObjects;

public class CabinClass : ValueObject
{
    private CabinClass(short value)
    {
        Value = (CabinClassEnum)Enum.ToObject(typeof(CabinClassEnum), value);

        CheckInvariants();
    }

    public CabinClassEnum Value { get; private set; }

    public static CabinClass Create(short cabinClass) => new(cabinClass);

    private void CheckInvariants()
    {
        var values = Enum.GetValues(typeof(CabinClassEnum)).Cast<short>().OrderBy(x => x);

        if (!values.Contains((short)Value))
        {
            throw new InvalidNumberOfTravelersException((short)Value);
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
