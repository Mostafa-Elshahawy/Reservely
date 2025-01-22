namespace Reserverly.Domain.Entities;

public class Flight 
{
    public int Id { get; set; }
    public string Airline { get; set; } = default!;
    public string FlightNumber { get; set; } = default!;
    public int DepartureLounge { get; set; } = default!;
    public int ArrivalLounge { get; set; } = default!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int AvailableSeats { get; set; }
    public int DepartureGate { get; set; }
    public int ArrivalGate { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int ClassPricingId { get; set; }
    public Airport DepartureAirport { get; set; } = default!;
    public Airport ArrivalAirport { get; set; } = default!;
    public ICollection<FlightClassPricing> ClassPricing { get; set; } = new List<FlightClassPricing>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
