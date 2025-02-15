using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Users.Commands.Auth;
using Reserverly.Application.Users.Commands.LoginUser;
using Reserverly.Application.Users.Queries.GetCurrentUser;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
    {
        var result = await mediator.Send(registerUserCommand);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
    {
        var result = await mediator.Send(loginUserCommand);
        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await Task.CompletedTask;
        return NoContent();
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var getCurrentUserQuery = new GetCurrentUserQuery();
        var user = await mediator.Send(getCurrentUserQuery);
        return Ok(user);
    }
}
