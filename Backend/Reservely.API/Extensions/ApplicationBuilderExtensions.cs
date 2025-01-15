using Serilog;

namespace Reservely.API.Extensions;
public static class ServiceCollectionExtensions
{
    public static void addPresentation(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
         configuration.ReadFrom.Configuration(context.Configuration)
        );
    }
}
