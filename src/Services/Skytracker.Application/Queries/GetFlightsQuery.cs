using BuilderPart.Application.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skytracker.Application.Queries
{
    internal class GetFlightsQuery : IQuery<IEnumerable<GetFlightsResponse>>
    {
        public DateTime Departure { get; set; }

        public DateTime Return { get; set; }
        
        public string From { get; set; }
        
        public string To { get; set; }
        
        public short NumberOfTravelers { get; set; }
        
        public short CabinClass { get; set; }
    }
}
