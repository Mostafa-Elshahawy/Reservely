using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservely.Infrastructure.ApplicationContext;
using Reservely.Infrastructure.Repositories;
using Reserverly.Domain.Repositories;

namespace Reservely.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReservelyDBContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ReservelyDB"));
        });

        services.AddScoped<IFlightsRepository, FlightsRepository>();
    }


}