using BuilderPart.Domain;
using Skytracker.Domain.ValueObjects;

namespace Skytracker.Domain.Exceptions
{
    public class InvalidNumberOfTravelersException : DomainException
    {
        public InvalidNumberOfTravelersException(short numberOfTravelers) 
            : base($"Given value '{numberOfTravelers}' is invalid.")
        {
        }
    }
}
