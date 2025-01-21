using Microsoft.Extensions.DependencyInjection;
using Reserverly.Application.Users;


namespace Reserverly.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        services.AddScoped<IUserContext, UserContext>();

        services.AddHttpContextAccessor();

    }
}
