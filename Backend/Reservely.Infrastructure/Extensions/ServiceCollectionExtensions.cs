using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservely.Infrastructure.ApplicationContext;

namespace Reservely.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ReservelyDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ReservelyDB")));

}