using Microsoft.AspNetCore.Identity;

namespace Reserverly.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => $"{FirstName} {LastName}";
    public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
