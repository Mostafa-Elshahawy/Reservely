using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.DeleteFlight;

public class DeleteFlightCommandHandler(IFlightsRepository flightsRepository, ILogger<DeleteFlightCommandHandler> logger) : IRequestHandler<DeleteFlightCommand>
{
    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting flight with id {request.Id}");
        var flight = await flightsRepository.GetById(request.Id);
        if (flight == null)
        {
            throw new NotFoundException(nameof(Flight), request.Id.ToString());
        }
        await flightsRepository.Delete(flight);
    }
}

