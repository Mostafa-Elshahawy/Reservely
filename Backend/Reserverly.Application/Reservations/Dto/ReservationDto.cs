using Reserverly.Domain.Entities;

namespace Reserverly.Application.Reservations.Dto;

public class ReservationDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int NumberOfSeats { get; set; }
    public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
    public ReservationStatus ReservationStatus { get; set; }
    public string Airline { get; set; } = default!;
    public string FlightNumber { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Duration { get; set; } = default!;
    public int DepartureLounge { get; set; }
    public int ArrivalLounge { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string? DepartureAirport { get; set; }
    public string? ArrivalAirport { get; set; }
    public string? DepartureCity { get; set; }
    public string? DepartureCountry { get; set; }
    public string? ArrivalCity { get; set; }
    public string? ArrivalCountry { get; set; }
    public FlightClassType FlightClassType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
