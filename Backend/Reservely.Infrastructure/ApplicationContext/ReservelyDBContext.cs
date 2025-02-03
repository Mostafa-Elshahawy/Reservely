using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reserverly.Domain.Entities;

namespace Reservely.Infrastructure.ApplicationContext;

internal class ReservelyDBContext(DbContextOptions<ReservelyDBContext> options) : IdentityDbContext<User>(options)
   
{
    internal DbSet<Reservation> Reservations { get; set; }
    internal DbSet<Flight> Flights { get; set; }
    internal DbSet<FlightClass> FlightClasses { get; set; }
    internal DbSet<Airport> Airports { get; set; }
}

