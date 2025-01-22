using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;

namespace Reserverly.Application.Users.Commands.RemoveUserRole;

public class RemoveUserRoleCommandHandler(ILogger<RemoveUserRoleCommandHandler> logger,
    UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<RemoveUserRoleCommand>

{
    public async Task Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation($"Removing role {request.UserRole} from user {request.UserEmail}");

        var user = await userManager.FindByEmailAsync(request.UserEmail);
        if (user == null)
        {
            throw new NotFoundException(nameof(user), request.UserEmail);
        }

        var role = await roleManager.FindByNameAsync(request.UserRole);
        if (role == null)
        {
            throw new NotFoundException(nameof(user), request.UserRole);
        }

        await userManager.RemoveFromRoleAsync(user, request.UserRole);
    }
}
