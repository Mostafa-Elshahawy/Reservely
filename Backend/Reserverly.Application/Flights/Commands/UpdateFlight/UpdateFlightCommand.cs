using MediatR;

namespace Reserverly.Application.Flights.Commands.UpdateFlight;

public class UpdateFlightCommand : IRequest
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = default!;
    public int DepartureLounge { get; set; } = default!;
    public int ArrivalLounge { get; set; } = default!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int AvailableSeats { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int DepartureGate { get; set; }
    public int ArrivalGate { get; set; }
    public int ClassPricingId { get; set; }
}
