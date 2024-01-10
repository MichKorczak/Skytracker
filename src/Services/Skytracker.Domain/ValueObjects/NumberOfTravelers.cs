using BuilderPart.Domain;
using Skytracker.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skytracker.Domain.ValueObjects
{
    internal class NumberOfTravelers : ValueObject
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
            throw new NotImplementedException();
        }
    }
}
