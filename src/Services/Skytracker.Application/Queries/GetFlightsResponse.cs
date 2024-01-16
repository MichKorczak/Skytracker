namespace Skytracker.Application.Queries
{
    public class GetFlightsResponse
    {
        public Guid FlightId { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Return { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Company { get; set; }

        public short NumberOfSeats { get; set; }

        public short CabinClass { get; set; }
    }
}
