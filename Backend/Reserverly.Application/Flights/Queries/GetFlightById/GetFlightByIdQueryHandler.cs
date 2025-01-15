using AutoMapper;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Queries.GetFlightById;

public class GetFlightByIdQueryHandler(IFlightsRepository flightsRepository, IMapper mapper)
{
    public async Task<FlightDto?> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        var flight = await flightsRepository.GetById(request.Id) ?? throw new NotFoundException(nameof(Flight), request.Id.ToString());

        var flightDto = mapper.Map<FlightDto>(flight);

        return flightDto;
    }
}
