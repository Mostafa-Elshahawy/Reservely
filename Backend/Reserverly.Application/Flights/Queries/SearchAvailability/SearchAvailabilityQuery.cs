using MediatR;
using Reserverly.Application.Flights.Dtos;

namespace Reserverly.Application.Flights.Queries.SearchAvailability;

public class SearchAvailabilityQuery : IRequest<List<FlightDto>>
{
    public string DepartureCountry { get; set; } = string.Empty;
    public string ArrivalCountry { get; set; } = string.Empty;
    public string DepartureCity { get; set; } = string.Empty;
    public string ArrivalCity { get; set; } = string.Empty;
    public DateTime DepartureDate { get; set; } = DateTime.UtcNow.Date;
    public int Passengers { get; set; } = 1;
}
