using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;

namespace Reserverly.Domain.Repositories;

public interface IFlightsRepository
{
    Task<int> Create(Flight flight);
    Task<Flight?> GetById(int id);
    Task<IEnumerable<Flight>> GetAll();
    Task Update(Flight flight);
    Task Delete(Flight flight);
    Task<(IEnumerable<Flight>,int)> GetAllMatching(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    Task SaveChanges();
}
