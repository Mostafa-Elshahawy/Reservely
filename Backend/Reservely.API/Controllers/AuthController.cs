using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Repositories;
using Reserverly.Application.Users.Commands.Auth;
using Reserverly.Application.Users.Commands.LoginUser;
using Reserverly.Application.Users.Queries.GetCurrentUser;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator, ITokenServiceRepository tokenService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
    {
        var result = await mediator.Send(registerUserCommand);
        tokenService.SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
    {
        var result = await mediator.Send(loginUserCommand);
        tokenService.SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var token = Request.Cookies["refreshToken"];
        if (token == null) return BadRequest(new { message = "Token is required" });
        var revoked =  await tokenService.RevokeToken(token!);
        if (!revoked)
        {
            return BadRequest(new { message = "Invalid or expired refresh token" });
        }
        Response.Cookies.Delete("refreshToken");
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

    [Authorize]
    [HttpGet("refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var result = await tokenService.RefreshToken(refreshToken!);
        tokenService.SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
        return Ok(result);

    }

    [Authorize]
    [HttpPost("revoke")]
    public async Task<IActionResult> RevokeToken()
    {
        var token = Request.Cookies["refreshToken"];
        if (token == null) return BadRequest(new { message = "Token is required" });
        await tokenService.RevokeToken(token!);
        return NoContent();
    }
}
