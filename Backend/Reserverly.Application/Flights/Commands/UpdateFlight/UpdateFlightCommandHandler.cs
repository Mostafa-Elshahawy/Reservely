using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.UpdateFlight;

public class UpdateFlightCommandHandler(IFlightsRepository flightsRepository, IMapper mapper, ILogger<UpdateFlightCommandHandler> logger) : IRequestHandler<UpdateFlightCommand>
{
    public async Task Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating flight with id {request.Id}");
        var flight = await flightsRepository.GetById(request.Id);
        if (flight == null)
        {
            throw new NotFoundException(nameof(Flight), request.Id.ToString());
        }
        
        mapper.Map(request, flight);

        await flightsRepository.SaveChanges();
    }
}
