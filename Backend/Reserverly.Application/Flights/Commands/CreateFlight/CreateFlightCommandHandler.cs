using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Interfaces;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler(IMapper mapper, IFlightsRepository flightsRepository,ILogger<CreateFlightCommandHandler> logger,
    IFlightAuthorizationService flightAuthorizationService) : IRequestHandler<CreateFlightCommand, int>
{
    public async Task<int> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Creating a new flight {request}");
        var flight = mapper.Map<Flight>(request);

        if (!flightAuthorizationService.Authorize(flight, ResourceOperation.Create))
            throw new ForbidenException(nameof(ResourceOperation.Create));

        int id = await flightsRepository.Create(flight);
        return id;
    }
}