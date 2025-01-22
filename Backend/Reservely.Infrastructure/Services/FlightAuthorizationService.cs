using Microsoft.Extensions.Logging;
using Reserverly.Application.Users;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Interfaces;
using Reserverly.Domain.Repositories;

namespace Reservely.Infrastructure.Services;

public class FlightAuthorizationService(ILogger<FlightAuthorizationService> logger, IFlightsRepository flightsRepository,
    IUserContext userContext) : IFlightAuthorizationService
{
    public bool Authorize(Flight flight, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();

        if (user == null)
        {
            logger.LogWarning("User is not authenticated");
            return false;
        }

        if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Read)
        {
           logger.LogInformation("User {user} is authorized to {operation} on flight {flight}", user.Email, resourceOperation, flight.Id);
            return true;
        }

        if ((resourceOperation == ResourceOperation.Update || resourceOperation == ResourceOperation.Delete) && user.IsInRole(UserRoles.Admin))
        {
                logger.LogInformation("User {user} is authorized to {operation} on flight {flight}", user.Email, resourceOperation, flight.Id);
                return true;
        }

        return false;
    }
}
