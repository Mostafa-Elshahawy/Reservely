namespace Reserverly.Domain.Entities;

public class Flight 
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = default!;
    public string Departure { get; set; } = default!;
    public string Arrival { get; set; } = default!;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int AvailableSeats { get; set; }
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
