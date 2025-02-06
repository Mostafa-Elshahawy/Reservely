namespace Reserverly.Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public int NumberOfSeats { get; set; }
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; } = default!;
    public FlightClassType FlightClassType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    public DateTime? UpdatedAt { get; set; }
}

public enum ReservationStatus
{
    Pending,
    Confirmed,
    Cancelled
}