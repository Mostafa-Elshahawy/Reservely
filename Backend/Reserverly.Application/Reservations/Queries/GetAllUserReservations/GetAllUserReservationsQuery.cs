using MediatR;
using Reserverly.Application.Reservations.Dto;

namespace Reserverly.Application.Reservations.Queries.GetAllUserReservations;

public class GetAllUserReservationsQuery : IRequest<IEnumerable<ReservationDto>>
{
}
