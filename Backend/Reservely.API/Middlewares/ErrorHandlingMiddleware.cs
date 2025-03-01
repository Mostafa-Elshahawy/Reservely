using Newtonsoft.Json;
using Reserverly.Domain.Exceptions;

namespace Reservely.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch(NotFoundException notFound)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new { message = notFound.Message });
            logger.LogWarning(notFound, notFound.Message);
        }
        catch(ForbidenException forbidenException)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(new { message = forbidenException.Message });
            logger.LogWarning(forbidenException, forbidenException.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            var response = new
            {
                error = ex.Message,
                statusCode = context.Response.StatusCode = 500
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
