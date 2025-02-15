using MediatR;
using Reserverly.Application.Users.Dtos;

namespace Reserverly.Application.Users.Queries.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<UserDto>
{
}
