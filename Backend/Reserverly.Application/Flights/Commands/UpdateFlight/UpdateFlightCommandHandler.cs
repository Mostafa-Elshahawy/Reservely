using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Interfaces;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.UpdateFlight;

public class UpdateFlightCommandHandler(IFlightsRepository flightsRepository, IMapper mapper, ILogger<UpdateFlightCommandHandler> logger,
                IFlightAuthorizationService flightAuthorizationService) : IRequestHandler<UpdateFlightCommand>
{
    public async Task Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating flight with id {request.Id}");
        var flight = await flightsRepository.GetById(request.Id);
        if (flight == null)
        {
            throw new NotFoundException(nameof(Flight), request.Id.ToString());
        }

        if (!flightAuthorizationService.Authorize(flight, ResourceOperation.Update))
            throw new ForbidenException(nameof(ResourceOperation.Update));

        mapper.Map(request, flight);

        await flightsRepository.SaveChanges();
    }
}
