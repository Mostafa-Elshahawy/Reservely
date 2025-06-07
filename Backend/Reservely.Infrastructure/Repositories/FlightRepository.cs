using Microsoft.EntityFrameworkCore;
using Reservely.Infrastructure.ApplicationContext;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Reservely.Infrastructure.Repositories;

internal class FlightRepository(ReservelyDBContext dbContext) : IFlightRepository
{
    public async Task<int> Create(Flight flight)
    {
        await dbContext.Flights.AddAsync(flight);
        await dbContext.SaveChangesAsync();
        return flight.Id;
    }

    public async Task<Flight?> GetById(int id)
    {
       return await dbContext.Flights
                 .Include(f => f.DepartureAirport)
                 .Include(f => f.ArrivalAirport)
                 .Include(f => f.FlightClasses)
                 .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Flight>> GetAll()
    {
        return await dbContext.Flights.Include(f => f.DepartureAirport)
                                      .Include(f => f.ArrivalAirport)
                                      .Include(f => f.FlightClasses).ToListAsync();
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
      .Include(f => f.FlightClasses)
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

    public async Task<List<Flight>> SearchAvailability (string departureCountry, string arrivalCountry, string departureCity, string arrivalCity, DateTime departureDate, int passengers)
    {
        var flights = dbContext.Flights
         .AsNoTracking()
         .Include(f => f.FlightClasses)
         .Include(f => f.DepartureAirport)
         .Include(f => f.ArrivalAirport)
         .Where(f => f.DepartureAirport.Country == departureCountry &&
                     f.ArrivalAirport.Country == arrivalCountry &&
                     f.FlightClasses.Any(fc => fc.AvailableSeats >= passengers))
         .AsQueryable();


        if (!string.IsNullOrWhiteSpace(departureCity))
        {
            flights = flights.Where(f => f.DepartureAirport.City == departureCity);
        }
        if (!string.IsNullOrWhiteSpace(arrivalCity))
        {
            flights = flights.Where(f => f.ArrivalAirport.City == arrivalCity);
        }

        flights = flights.Where(f => f.DepartureTime.Date == departureDate.Date);

        return await flights.ToListAsync();
    }
}

