using BuilderPart.Application.Mediator;

namespace Skytracker.Application.Queries;

public class GetFlightsQuery : IQuery<IEnumerable<GetFlightsResponse>>
{
    public DateTime Departure { get; set; }

    public DateTime Return { get; set; }
    
    public string From { get; set; }
    
    public string To { get; set; }
    
    public short NumberOfTravelers { get; set; }
    
    public short CabinClass { get; set; }
}
