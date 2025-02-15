namespace Reserverly.Application.Users.Dtos;

public class AuthDto
{
    public string Token { get; set; } = default!;
    public UserDto User { get; set; } = default!;
}
