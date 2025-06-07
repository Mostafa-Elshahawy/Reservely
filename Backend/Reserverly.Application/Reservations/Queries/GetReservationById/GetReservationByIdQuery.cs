using MediatR;
using Reserverly.Application.Reservations.Dto;

namespace Reserverly.Application.Reservations.Queries.GetReservationById;

public class GetReservationByIdQuery(int reservationId, string userId) : IRequest<ReservationDto>
{
    public int ReservationId { get; } = reservationId;
    public string UserId { get; } = userId;
}
