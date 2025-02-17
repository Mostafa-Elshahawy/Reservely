using MediatR;
using Reserverly.Application.Users.Dtos;

namespace Reserverly.Application.Users.Commands.Auth;

public class RegisterUserCommand : IRequest<AuthDto>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
