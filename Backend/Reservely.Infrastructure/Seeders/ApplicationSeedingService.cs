using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reservely.Infrastructure.ApplicationContext;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;

namespace Reservely.Infrastructure.Seeders;

internal class ApplicationSeedingService(ReservelyDBContext dbContext) : IApplicationSeedingService
{
    public async Task Seed()
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Roles.Any())
            {
                var roles = SeedRoles();
                await dbContext.Roles.AddRangeAsync(roles);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.FlightClasses.Any())
            {
                var flightClasses = SeedFlightClasses();
                await dbContext.FlightClasses.AddRangeAsync(flightClasses);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Airports.Any())
            {
                var airports = SeedAirports();
                await dbContext.Airports.AddRangeAsync(airports);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Flights.Any())
            {
                var flights = SeedFlights();
                await dbContext.Flights.AddRangeAsync(flights);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> SeedRoles()
    {
        List<IdentityRole> roles = new List<IdentityRole>
    {
        new IdentityRole(UserRoles.User)
        {
            NormalizedName = UserRoles.User.ToUpper()
        },
        new IdentityRole(UserRoles.Admin)
        {
            NormalizedName = UserRoles.Admin.ToUpper()
        },
    };

        return roles;
    }

    private IEnumerable<Flight> SeedFlights()
    {
        var flights = new List<Flight>
    {
        new Flight
        {
            Airline = "Egypt Air",
            FlightNumber = "EG100",
            Status = FlightStatus.Scheduled,
            DepartureLounge = 1,
            ArrivalLounge = 3,
            DepartureTime = DateTime.UtcNow.AddDays(7).AddHours(10),
            ArrivalTime = DateTime.UtcNow.AddDays(7).AddHours(14),
            AvailableSeats = 100,
            DepartureAirportId = 1,
            ArrivalAirportId = 2,
        },
        new Flight
        {
            Airline = "Nile Air",
            FlightNumber = "NI101",
            Status = FlightStatus.Delayed,
            DepartureLounge = 1,
            ArrivalLounge = 3,
            DepartureTime = DateTime.UtcNow.AddDays(7).AddHours(13),
            ArrivalTime = DateTime.UtcNow.AddDays(7).AddHours(17),
            AvailableSeats = 97,
            DepartureAirportId = 1,
            ArrivalAirportId = 3,

        },
        new Flight
        {
            Airline = "Air Cairo",
            FlightNumber = "AC102",
            Status = FlightStatus.Scheduled,
            DepartureLounge = 1,
            ArrivalLounge = 3,
            DepartureTime = DateTime.UtcNow.AddDays(7).AddHours(16),
            ArrivalTime = DateTime.UtcNow.AddDays(7).AddHours(20),
            AvailableSeats = 94,
            DepartureAirportId = 1,
            ArrivalAirportId = 4,
        },
        new Flight
        {
            Airline = "Fly Dubai",
            FlightNumber = "FL103",
            Status = FlightStatus.InFlight,
            DepartureLounge = 1,
            ArrivalLounge = 3,
            DepartureTime = DateTime.UtcNow.AddHours(-1),
            ArrivalTime = DateTime.UtcNow.AddHours(3),
            AvailableSeats = 91,
            DepartureAirportId = 1,
            ArrivalAirportId = 5,
        },
        new Flight
        {
            Airline = "Qatar Airways",
            FlightNumber = "QA104",
            Status = FlightStatus.Cancelled,
            DepartureLounge = 1,
            ArrivalLounge = 3,
            DepartureTime = DateTime.UtcNow.AddDays(8).AddHours(10),
            ArrivalTime = DateTime.UtcNow.AddDays(8).AddHours(14),
            AvailableSeats = 88,
            DepartureAirportId = 1,
            ArrivalAirportId = 6,
        },
    };

        return flights;
    }

    private IEnumerable<FlightClass> SeedFlightClasses()
    {
        return new List<FlightClass>
        {
        new FlightClass { Name = "Economy" },
        new FlightClass { Name = "Business" },
        new FlightClass { Name = "First Class" }
        };
    }

    private IEnumerable<Airport> SeedAirports()
    {
        return new List<Airport>
    {
        new Airport { Name = "Cairo International Airport", City = "Cairo", Country = "Egypt", Gates = 20 },
        new Airport { Name = "Heathrow Airport", City = "London", Country = "UK", Gates = 18 },
        new Airport { Name = "Charles de Gaulle Airport", City = "Paris", Country = "France", Gates = 10 },
        new Airport { Name = "Dubai International Airport", City = "Dubai", Country = "UAE", Gates = 14 },
        new Airport { Name = "JFK International Airport", City = "New York", Country = "USA", Gates = 13 },
        new Airport { Name = "King Abdulaziz Airport", City = "Jeddah", Country = "Saudi Arabia", Gates = 16 }
    };
    }


}

