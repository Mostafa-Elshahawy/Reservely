using AutoMapper;
using Reserverly.Application.Users.Commands.Auth;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Users.Dtos;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<RegisterUserCommand, User>();
    }
}
