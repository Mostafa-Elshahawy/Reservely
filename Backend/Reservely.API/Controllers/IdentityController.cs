using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Users.Commands.AssignUserRole;
using Reserverly.Application.Users.Commands.RemoveUserRole;
using Reserverly.Domain.Constants;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> RemoveUserRole(RemoveUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}
