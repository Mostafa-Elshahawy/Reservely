using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reserverly.Application.Repositories;
using Reserverly.Application.Users.Dtos;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Reservely.Infrastructure.Services;

public class TokenService(IConfiguration configuration, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor) : ITokenServiceRepository
{
    public async Task<string> GenerateToken(User user)
    {
        var userClaims = await userManager.GetClaimsAsync(user);
        var userRoles = await userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in userRoles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("uid", user.Id)
        }.Union(userClaims).Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token;
    }
    
    public async Task<AuthDto> RefreshToken(string token)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));
        if (user == null)
        {
            throw new NotFoundException(nameof(User), "User");
        }

        var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

        if (!refreshToken.IsActive)
        {
            throw new UnauthorizedAccessException("Invalid refresh token");
        }

        refreshToken.RevokedOn = DateTime.UtcNow;
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshTokens.Add(newRefreshToken);
        await userManager.UpdateAsync(user);

        var newToken = await GenerateToken(user);

        return new AuthDto
        {
            Token = newToken,
            RefreshToken = newRefreshToken.Token
        };
    }

    public async Task<bool> RevokeToken(string token)
    {
        var user = await userManager.Users.Include(u=>u.RefreshTokens).SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));
        if (user == null)
        {
            throw new NotFoundException(nameof(User), "User");
        }

        var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
        if (!refreshToken.IsActive || refreshToken ==null) {
            throw new UnauthorizedAccessException("Invalid refresh token");
        }

        refreshToken.RevokedOn = DateTime.UtcNow;
        await userManager.UpdateAsync(user);

        return true;
    }

    public RefreshToken GenerateRefreshToken()
    {
        var randomNumber = new byte[32];

        RandomNumberGenerator.Fill(randomNumber);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomNumber),
            ExpiresOn = DateTime.UtcNow.AddDays(10),
            CreatedOn = DateTime.UtcNow
        };
    }

    public void SetRefreshTokenInCookie(string token, DateTime expires)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = expires.ToLocalTime(),
            SameSite = SameSiteMode.None,
            Secure = true,
            IsEssential = true
        };

        httpContextAccessor.HttpContext!.Response.Cookies.Append("refreshToken", token, cookieOptions);
    }
}
