using Microsoft.AspNetCore.Identity;

namespace Reserverly.Domain.Entities;

public class User : IdentityUser
{
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
