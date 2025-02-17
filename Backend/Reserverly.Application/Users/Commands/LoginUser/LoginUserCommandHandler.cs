using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Repositories;
using Reserverly.Application.Users.Dtos;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;


namespace Reserverly.Application.Users.Commands.LoginUser;

class LoginUserCommandHandler(ILogger<LoginUserCommandHandler> logger, IMapper mapper, UserManager<User> userManager,
    ITokenServiceRepository tokenService) : IRequestHandler<LoginUserCommand, AuthDto>
{
    public async Task<AuthDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Logging in user with email {request.Email}");

        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Email);
        }
        var result = await userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            throw new UnauthorizedAccessException("Invalid email or password");
        }

        var userDto = mapper.Map<UserDto>(user);
        var userRoles = await userManager.GetRolesAsync(user);
        userDto.Roles = userRoles.ToList();

        var accessToken = await tokenService.GenerateToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();
        user.RefreshTokens.Add(refreshToken);
        await userManager.UpdateAsync(user);

        return new AuthDto
        {
            User = userDto,
            Token = accessToken,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiration = refreshToken.ExpiresOn
        };
    }
}
