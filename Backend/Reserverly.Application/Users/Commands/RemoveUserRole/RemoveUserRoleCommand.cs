using MediatR;

namespace Reserverly.Application.Users.Commands.RemoveUserRole;

public class RemoveUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string UserRole { get; set; } = default!;
}
