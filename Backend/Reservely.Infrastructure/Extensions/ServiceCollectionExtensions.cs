using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservely.Infrastructure.ApplicationContext;
using Reservely.Infrastructure.Repositories;
using Reservely.Infrastructure.Seeders;
using Reservely.Infrastructure.Services;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Interfaces;
using Reserverly.Domain.Repositories;


namespace Reservely.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ReservelyDB");
        services.AddDbContext<ReservelyDBContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddIdentityApiEndpoints<User>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<ReservelyDBContext>();

        services.AddScoped<IApplicationSeedingService, ApplicationSeedingService>();
        services.AddScoped<IFlightsRepository, FlightsRepository>();
        services.AddScoped<IFlightAuthorizationService, FlightAuthorizationService>();
    }
}