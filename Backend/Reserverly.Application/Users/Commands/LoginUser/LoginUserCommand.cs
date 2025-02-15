using MediatR;
using Reserverly.Application.Users.Dtos;

namespace Reserverly.Application.Users.Commands.LoginUser;

public class LoginUserCommand(string email, string password) : IRequest<UserDto>
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}