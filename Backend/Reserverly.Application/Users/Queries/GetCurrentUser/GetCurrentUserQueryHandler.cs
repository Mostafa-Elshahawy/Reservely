using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Users.Dtos;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;

namespace Reserverly.Application.Users.Queries.GetCurrentUser;

public class GetCurrentUserQueryHandler(IUserContext userContext,ILogger<GetCurrentUserQueryHandler> logger,
                                            UserManager<User> userManager, IMapper mapper) : IRequestHandler<GetCurrentUserQuery, UserDto>
{
    public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting current user");

        var currentUser = userContext.GetCurrentUser();
        if (currentUser == null)
        {
            throw new UnauthorizedAccessException("User is not authenticated");
        }

        var user = await userManager.FindByIdAsync(currentUser.Id);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), currentUser.Id);
        }

        var userDto = mapper.Map<UserDto>(user);
        userDto.Roles = currentUser.Roles.ToList();

        return userDto;
    }
}
