using MediatR;
using Reserverly.Application.Common;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Constants;
using System.ComponentModel;

namespace Reserverly.Application.Flights.Queries.GetAllFlights;

public class GetAllFlightsQuery : IRequest<PagedResult<FlightDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
