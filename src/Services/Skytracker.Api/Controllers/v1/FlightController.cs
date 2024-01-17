using BuilderPart.Application.Mediator;
using Microsoft.AspNetCore.Mvc;
using Skytracker.Application.Queries;

namespace Skytracker.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IBus _bus;

        public FlightController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet("{departure}/{returnDate}/{from}/{to}/{numberOfTravelers}/{cabinClass}")]
        public async Task<IActionResult> GetFlights(
            DateTime departure, DateTime returnDate, string from, string to, short numberOfTravelers, short cabinClass)
        {
            var query = new GetFlightsQuery {
                 CabinClass = cabinClass,
                 Departure = departure,
                 Return = returnDate,
                 From = from,
                 To = to,
                 NumberOfTravelers = numberOfTravelers                 
            };

            var result = await _bus.SendAsync(query);

            return Ok(result);
        }
    }
}
