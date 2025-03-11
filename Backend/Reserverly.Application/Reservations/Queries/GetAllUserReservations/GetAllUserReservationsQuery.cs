using MediatR;
using Reserverly.Application.Reservations.Dto;

namespace Reserverly.Application.Reservations.Queries.GetAllUserReservations;

public class GetAllUserReservationsQuery(string userId) : IRequest<IEnumerable<ReservationDto>>
{
    public string UserId { get; } = userId;
}
