using System.Text.Json.Serialization;

namespace Reserverly.Application.Flights.Dtos;

public class FlightDto
{
    public int Id { get; set; }
    public string Airline { get; set; } = default!;
    public string FlightNumber { get; set; } = default!;
    public string Status { get; set; } = default!;

    [JsonIgnore]
    public TimeSpan Duration { get; set; }

    [JsonPropertyName("duration")]
    public string FormattedDuration => $"{Duration.Hours:D2}:{Duration.Minutes:D2}";
    public int AvailableSeats { get; set; }
    public int DepartureLounge { get; set; } = default!;
    public int ArrivalLounge { get; set; } = default!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string DepartureAirport { get; set; } = default!;
    public string ArrivalAirport { get; set; } = default!;
    public string DepartureCity { get; set; } = default!;
    public string DepartureCountry { get; set; } = default!;
    public string ArrivalCity { get; set; } = default!;
    public string ArrivalCountry { get; set; } = default!;
    public int ClassPricingId { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }
}
