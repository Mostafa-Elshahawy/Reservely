using AutoMapper;
using MediatR;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler(IMapper mapper, IFlightsRepository flightsRepository) : IRequestHandler<CreateFlightCommand, int>
{
    public async Task<int> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = mapper.Map<Flight>(request);

        int id = await flightsRepository.Create(flight);
        return id;
    }
}