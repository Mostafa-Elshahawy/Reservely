using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;

namespace Reserverly.Domain.Interfaces;

public interface IFlightAuthorizationService 
{
    bool Authorize(Flight flight, ResourceOperation resourceOperation);
}
