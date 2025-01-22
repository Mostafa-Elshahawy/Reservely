using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;

namespace Reserverly.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation($"Assigning role {request.UserRole} to user {request.UserEmail}");

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

        await userManager.AddToRoleAsync(user, request.UserRole);
    }
}
