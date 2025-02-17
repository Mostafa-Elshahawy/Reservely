using Reserverly.Application.Users.Dtos;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Repositories;

public interface ITokenServiceRepository 
{
    Task<string> GenerateToken(User user);
    Task<AuthDto> RefreshToken(string token);
    Task<bool> RevokeToken(string token);
    void SetRefreshTokenInCookie(string token, DateTime expires);
    RefreshToken GenerateRefreshToken();
}
