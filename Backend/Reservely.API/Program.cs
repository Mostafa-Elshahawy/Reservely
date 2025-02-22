using Microsoft.AspNetCore.Mvc;
using Reservely.API.Extensions;
using Reservely.API.Middlewares;
using Reservely.Infrastructure.Extensions;
using Reservely.Infrastructure.Seeders;
using Reserverly.Application.Extensions;
using Serilog;

namespace Reservely.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();

        builder.AddPresentation();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<IApplicationSeedingService>();

        await seeder.Seed();

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
