using System.Text.Json.Serialization;

namespace Reserverly.Application.Users.Dtos;

public class AuthDto
{
    public string Token { get; set; } = default!;
    public UserDto User { get; set; } = default!;

    [JsonIgnore]
    public string RefreshToken { get; set; } = default!;
    public DateTime RefreshTokenExpiration { get; set; }
}
