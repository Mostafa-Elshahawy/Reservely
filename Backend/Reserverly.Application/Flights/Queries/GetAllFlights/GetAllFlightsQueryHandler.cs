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
        var flights = await flightsRepository.GetAll();
        var flightsDto = mapper.Map<IEnumerable<FlightDto>>(flights);
        return new PagedResult<FlightDto>(flightsDto, flightsDto.Count(), request.PageSize, request.PageNumber);
    }
}