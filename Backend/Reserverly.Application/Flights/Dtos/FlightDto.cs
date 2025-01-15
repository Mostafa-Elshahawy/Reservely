namespace Reserverly.Application.Flights.Dtos;

public class FlightDto
{
    public int Id { get; set; }
    public string Airline { get; set; } = default!;
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
    public string DepartureAirport { get; set; } = default!;
    public string ArrivalAirport { get; set; } = default!;
    public string Class { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
