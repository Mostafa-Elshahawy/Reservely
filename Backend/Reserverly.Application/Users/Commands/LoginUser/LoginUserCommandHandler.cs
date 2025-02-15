using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Users.Dtos;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Repositories;
using System.Security.Claims;

namespace Reserverly.Application.Users.Commands.LoginUser;

class LoginUserCommandHandler(ILogger<LoginUserCommandHandler> logger, IMapper mapper, UserManager<User> userManager,
    ITokenServiceRepository tokenService) : IRequestHandler<LoginUserCommand, UserDto>
{
    public async Task<UserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
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
        await tokenService.GenerateToken(user);

        return userDto;
    }
}
