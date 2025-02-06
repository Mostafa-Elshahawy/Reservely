using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;

namespace Reserverly.Domain.Interfaces;

public interface IReservationAuthorizationService
{
    bool Authorize(Reservation reservation, ResourceOperation resourceOperation);
}
