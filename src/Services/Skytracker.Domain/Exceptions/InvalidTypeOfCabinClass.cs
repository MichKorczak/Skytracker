using BuilderPart.Domain;
using Skytracker.Domain.ValueObjects;

namespace Skytracker.Domain.Exceptions
{
    public class InvalidTypeOfCabinClass : DomainException
    {
        protected InvalidTypeOfCabinClass(short cabinClassInt)
            : base($"Given value '{cabinClassInt}' is out of range of Cabin Class.")
        {
        }
    }
}
