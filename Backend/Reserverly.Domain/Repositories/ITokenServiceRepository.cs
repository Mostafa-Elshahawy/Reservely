using Reserverly.Domain.Entities;

namespace Reserverly.Domain.Repositories;

public interface ITokenServiceRepository
{
    Task<string> GenerateToken(User user);
}
