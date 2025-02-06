using Microsoft.Extensions.Logging;
using Reserverly.Application.Users;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Interfaces;

namespace Reservely.Infrastructure.Services;

public class ReservationAuthorizationService(ILogger<ReservationAuthorizationService> logger,
                                                IUserContext userContext) : IReservationAuthorizationService
{
    public bool Authorize(Reservation reservation, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();
        if (user == null)
        {
            return false;
        }
        if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Read)
        {
            logger.LogInformation("User {user} is authorized to {operation} on reservation {reservation}", user.Email, resourceOperation, reservation.Id);
            return true;
        }
        if ((resourceOperation == ResourceOperation.Update || resourceOperation == ResourceOperation.Delete) && user.IsInRole(UserRoles.User))
        {
            logger.LogInformation("User {user} is authorized to {operation} on reservation {reservation}", user.Email, resourceOperation, reservation.Id);
            return true;
        }
        return false;
    }
}
