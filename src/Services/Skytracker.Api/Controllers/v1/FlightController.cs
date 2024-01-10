using BuilderPart.Application.Mediator;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            return Ok();
        }
    }
}
