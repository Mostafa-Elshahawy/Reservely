using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Users.Commands.AssignUserRole;
using Reserverly.Application.Users.Commands.RemoveUserRole;
using Reserverly.Application.Users.Dtos;
using Reserverly.Application.Users.Queries.GetAllUsers;
using Reserverly.Domain.Constants;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = UserRoles.Admin)]
public class UsersController(IMediator mediator) : ControllerBase
{

    [HttpPost("assignRole")]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("unassignRole")]
    public async Task<IActionResult> RemoveUserRole(RemoveUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var query = new GetAllUsersQuery();
        var users = await mediator.Send(query);
        return Ok(users);
    }
}
