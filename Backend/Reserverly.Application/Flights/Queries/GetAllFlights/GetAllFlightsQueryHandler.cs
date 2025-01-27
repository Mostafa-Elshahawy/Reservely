using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Common;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Flights.Queries.GetAllFlights;

public class GetAllFlightsQueryHandler(IFlightsRepository flightsRepository, IMapper mapper, ILogger<GetAllFlightsQueryHandler> logger) : IRequestHandler<GetAllFlightsQuery, PagedResult<FlightDto>>
{

    public async Task<PagedResult<FlightDto>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all flights");
        var (flights, totalCount) = await flightsRepository.GetAllMatching(request.SearchPhrase,
            request.PageSize,
            request.PageNumber,
            request.SortBy, 
            request.SortDirection);
        var flightsDtos = mapper.Map<IEnumerable<FlightDto>>(flights);
       
        var result = new PagedResult<FlightDto>(flightsDtos, totalCount, request.PageNumber, request.PageSize);
        return result;
    }
}