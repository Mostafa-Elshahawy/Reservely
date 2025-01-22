using System.ComponentModel.DataAnnotations.Schema;

namespace Reserverly.Domain.Entities;

public class FlightClassPricing
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; } = default!;
    public int FlightClassId { get; set; }
    public FlightClass FlightClass { get; set; } = default!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
