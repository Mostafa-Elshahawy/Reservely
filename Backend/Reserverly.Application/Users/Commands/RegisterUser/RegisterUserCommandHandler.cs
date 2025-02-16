using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Repositories;
using Reserverly.Application.Users.Dtos;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Users.Commands.Auth;
public class RegisterUserCommandHandler(ITokenServiceRepository tokenService, IMapper mapper, 
                                        ILogger<RegisterUserCommandHandler> logger, UserManager<User> userManager)
                                        : IRequestHandler<RegisterUserCommand, AuthDto>
{
    public async Task<AuthDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Registering a new user {request}");

        var user = mapper.Map<User>(request);
        user.UserName = request.Email;

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            logger.LogError($"Failed to register user: {errors}");
            throw new Exception($"User registration failed: {errors}");
        }

        await userManager.AddToRoleAsync(user, "User");

        var roles = await userManager.GetRolesAsync(user);
        var userDto = mapper.Map<UserDto>(user);
        userDto.Roles = roles.ToList();

        var token = await tokenService.GenerateToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();
        user.RefreshTokens.Add(refreshToken);
        await userManager.UpdateAsync(user);


        return new AuthDto
        {
            User = userDto,
            Token = token,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiration = refreshToken.ExpiresOn
        };
    }
}
