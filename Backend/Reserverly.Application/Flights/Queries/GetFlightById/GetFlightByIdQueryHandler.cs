using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Queries.GetFlightById;

public class GetFlightByIdQueryHandler(IFlightsRepository flightsRepository, IMapper mapper, ILogger<GetFlightByIdQueryHandler> logger) : IRequestHandler<GetFlightByIdQuery, FlightDto?>
{
    public async Task<FlightDto?> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting flight with id {request.Id}");
        var flight = await flightsRepository.GetById(request.Id) ?? throw new NotFoundException(nameof(Flight), request.Id.ToString());

        var flightDto = mapper.Map<FlightDto>(flight);

        return flightDto;
    }
}
