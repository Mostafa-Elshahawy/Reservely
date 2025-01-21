using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler(IMapper mapper, IFlightsRepository flightsRepository,ILogger<CreateFlightCommandHandler> logger) : IRequestHandler<CreateFlightCommand, int>
{
    public async Task<int> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Creating a new flight {request}");
        var flight = mapper.Map<Flight>(request);

        int id = await flightsRepository.Create(flight);
        return id;
    }
}