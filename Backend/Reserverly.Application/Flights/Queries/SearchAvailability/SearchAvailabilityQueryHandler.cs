using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Queries.SearchAvailability;

public class SearchAvailabilityQueryHandler(ILogger<SearchAvailabilityQueryHandler> logger, IMapper mapper, IFlightRepository flightRepository)
                                                :IRequestHandler<SearchAvailabilityQuery, List<FlightDto>>
{
    public async Task<List<FlightDto>> Handle(SearchAvailabilityQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Searching for flights: {DepartureCountry} to {ArrivalCountry} on {DepartureDate} for {Passengers} passengers",
                               request.DepartureCountry, request.ArrivalCountry, request.DepartureDate.Date, request.Passengers);

        var flights = await flightRepository.SearchAvailability(request.DepartureCountry,
                                                                request.ArrivalCountry,
                                                                request.DepartureCity,
                                                                request.ArrivalCity,
                                                                request.DepartureDate,
                                                                request.Passengers);

        return mapper.Map<List<FlightDto>>(flights);
    }
}
