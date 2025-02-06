using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Interfaces;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.DeleteFlight;

public class DeleteFlightCommandHandler(IFlightRepository flightsRepository, ILogger<DeleteFlightCommandHandler> logger,
                    IFlightAuthorizationService flightAuthorizationService) : IRequestHandler<DeleteFlightCommand>
{
    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting flight with id {request.Id}");
        var flight = await flightsRepository.GetById(request.Id);

        if (flight == null)
            throw new NotFoundException(nameof(Flight), request.Id.ToString());

        if (!flightAuthorizationService.Authorize(flight, ResourceOperation.Delete))
            throw new ForbidenException(nameof(ResourceOperation.Delete));

        await flightsRepository.Delete(flight);
    }
}

