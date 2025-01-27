using Microsoft.EntityFrameworkCore;
using Reservely.Infrastructure.ApplicationContext;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;
using System.Linq.Expressions;

namespace Reservely.Infrastructure.Repositories;

internal class FlightsRepository(ReservelyDBContext dbContext) : IFlightsRepository
{
    public async Task<int> Create(Flight flight)
    {
        await dbContext.Flights.AddAsync(flight);
        await dbContext.SaveChangesAsync();
        return flight.Id;
    }

    public async Task<Flight?> GetById(int id) => await dbContext.Flights
                 .Include(f => f.DepartureAirport)
                 .Include(f => f.ArrivalAirport)
                 .Include(f => f.ClassPricing)
                 .FirstOrDefaultAsync(f => f.Id == id);

    public async Task<IEnumerable<Flight>> GetAll()
    {
        return await dbContext.Flights.Include(f => f.DepartureAirport).Include(f => f.ArrivalAirport)
            .Include(f => f.ClassPricing).Include(f => f.Status)
            .ToListAsync();
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

    public async Task<(IEnumerable<Flight>, int)> GetAllMatching(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var query = dbContext.Flights
      .Include(f => f.DepartureAirport)
      .Include(f => f.ArrivalAirport)
      .Include(f => f.ClassPricing)
      .Where(f => searchPhraseLower == null ||
         (f.FlightNumber.ToLower().Contains(searchPhraseLower) ||
          f.Airline.ToLower().Contains(searchPhraseLower) ||
          f.DepartureCountry.ToLower().Contains(searchPhraseLower) ||
          f.ArrivalCountry.ToLower().Contains(searchPhraseLower)));

        var totalItems = await query.CountAsync();

        if(sortBy != null)
        {
              var columnSelector = new Dictionary<string, Expression<Func<Flight, object>>>
              {
                   { nameof(Flight.FlightNumber), f => f.FlightNumber },
                   { nameof(Flight.Airline), f => f.Airline },
                   { nameof(Flight.DepartureCountry), f => f.DepartureCountry },
                   { nameof(Flight.ArrivalCountry)    , f => f.ArrivalCountry }
              };

            var selectedColumn = columnSelector[sortBy];

            query = sortDirection == SortDirection.Ascending ? query.OrderBy(selectedColumn) : query.OrderByDescending(selectedColumn);

        }

        var Filteredflights = await query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        return (Filteredflights, totalItems);
    }

    public Task SaveChanges() => dbContext.SaveChangesAsync();
}

