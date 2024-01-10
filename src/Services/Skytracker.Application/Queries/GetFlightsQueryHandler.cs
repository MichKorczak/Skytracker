using BuilderPart.Application.Mediator;
using Skytracker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skytracker.Application.Queries
{
    internal class GetFlightsQueryHandler : IQueryHandler<GetFlightsQuery, IEnumerable<GetFlightsResponse>>
    {
        private readonly IFlightRepository _repository;

        public GetFlightsQueryHandler(IFlightRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetFlightsResponse>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetFlightsAsync(new spec);

        }
    }
}
