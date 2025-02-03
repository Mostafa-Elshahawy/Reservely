using System.ComponentModel.DataAnnotations.Schema;

namespace Reserverly.Domain.Entities;

public class FlightClass
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; } = default!;
    public FlightClassType ClassType { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public enum FlightClassType
{
    Economy,
    Business,
    FirstClass
}