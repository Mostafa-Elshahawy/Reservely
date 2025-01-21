using Reservely.API.Middlewares;
using Serilog;

namespace Reservely.API.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddAuthentication();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<ErrorHandlingMiddleware>();

        builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)
        );

    }
}
