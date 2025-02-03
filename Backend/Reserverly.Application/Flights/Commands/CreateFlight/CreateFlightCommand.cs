using MediatR;
using Reserverly.Application.Flights.Dtos;

namespace Reserverly.Application.Flights.Commands.CreateFlight;

public class CreateFlightCommand : IRequest<int>
{
    public string Airline { get; set; } = default!;
    public string FlightNumber { get; set; } = default!;
    public int DepartureLounge { get; set; } = default!;
    public int ArrivalLounge { get; set; } = default!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public List<FlightClassDto> FlightClasses { get; set; } = [];
}
