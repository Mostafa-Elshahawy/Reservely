using MediatR;
using Reserverly.Application.Users.Dtos;

namespace Reserverly.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{

}
