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

            if (!dbContext.Airports.Any())
            {
                var airports = SeedAirports();
                await dbContext.Airports.AddRangeAsync(airports);
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

