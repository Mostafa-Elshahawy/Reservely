using System.ComponentModel.DataAnnotations.Schema;

namespace Reserverly.Domain.Entities;

public class FlightClass
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
