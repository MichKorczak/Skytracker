using BuilderPart.Application.Mediator;
using MapsterMapper;
using Skytracker.Domain.Repositories;
using Skytracker.Domain.Specifications;

namespace Skytracker.Application.Queries;

public class GetFlightsQueryHandler : IQueryHandler<GetFlightsQuery, IEnumerable<GetFlightsResponse>>
{
    private readonly IFlightRepository _repository;
    private readonly IMapper _mapper;

    public GetFlightsQueryHandler(IFlightRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetFlightsResponse>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
    {
        var specification = new FlightDestinationSpecification(request.To);
        var response = await _repository.GetFlightsAsync(specification);

        return _mapper.Map<IEnumerable<GetFlightsResponse>>(response);
    }
}
