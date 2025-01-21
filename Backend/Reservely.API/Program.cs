using Reservely.API.Extensions;
using Reservely.API.Middlewares;
using Reservely.Infrastructure.Extensions;
using Reserverly.Application.Extensions;
using Reserverly.Domain.Entities;
using Serilog;

namespace Reservely.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();

        builder.AddPresentation();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options=>options.SwaggerEndpoint("/openapi/v1.json","v1"));
        }

        app.MapGroup("api/identity")
        .WithTags("Identity")
        .MapIdentityApi<User>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
