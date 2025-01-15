using AutoMapper;
using MediatR;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.DeleteFlight;

public class DeleteFlightCommandHandler(IFlightsRepository flightsRepository) : IRequestHandler<DeleteFlightCommand>
{
    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = await flightsRepository.GetById(request.Id);
        if (flight == null)
        {
            throw new NotFoundException(nameof(Flight), request.Id.ToString());
        }
        await flightsRepository.Delete(flight);
    }
}

