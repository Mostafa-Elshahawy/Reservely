namespace Reserverly.Domain.Entities;

public class Flight 
{
    public int Id { get; set; }
    public string Airline { get; set; } = default!;
    public string FlightNumber { get; set; } = default!;
    public TimeSpan Duration => ArrivalTime - DepartureTime;
    public FlightStatus Status { get; set; } = FlightStatus.Scheduled;
    public int DepartureLounge { get; set; } = default!;
    public int ArrivalLounge { get; set; } = default!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int AvailableSeats { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int ClassPricingId { get; set; }
    public Airport DepartureAirport { get; set; } = default!;
    public Airport ArrivalAirport { get; set; } = default!;
    public string DepartureCity => DepartureAirport.City; 
    public string DepartureCountry => DepartureAirport.Country;
    public string ArrivalCity => ArrivalAirport.City;
    public string ArrivalCountry => ArrivalAirport.Country;
    public ICollection<FlightClassPricing> ClassPricing { get; set; } = new List<FlightClassPricing>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}


public enum FlightStatus
{
    Scheduled,
    Delayed,
    Cancelled,
    InFlight,
    Landed
}