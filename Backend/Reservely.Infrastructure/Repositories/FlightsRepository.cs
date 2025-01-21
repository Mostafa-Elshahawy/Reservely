using Microsoft.EntityFrameworkCore;
using Reservely.Infrastructure.ApplicationContext;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;

namespace Reservely.Infrastructure.Repositories;

internal class FlightsRepository(ReservelyDBContext dbContext) : IFlightsRepository
{
    public async Task<int> Create(Flight flight)
    {
        await dbContext.Flights.AddAsync(flight);
        await dbContext.SaveChangesAsync();
        return flight.Id;
    }

    public async Task<Flight?> GetById(int id)
    {
        return await dbContext.Flights.FindAsync(id);
    }

    public async Task<IEnumerable<Flight>> GetAll()
    {
        return await dbContext.Flights.ToListAsync();
    }

    public async Task Update(Flight flight)
    {
        dbContext.Flights.Update(flight);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Flight flight)
    {
        dbContext.Flights.Remove(flight);
        await dbContext.SaveChangesAsync();
    }

    public Task SaveChanges() => dbContext.SaveChangesAsync();
}

