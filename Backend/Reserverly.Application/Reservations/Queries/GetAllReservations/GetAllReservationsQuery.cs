using MediatR;
using Reserverly.Application.Reservations.Dto;

namespace Reserverly.Application.Reservations.Queries.GetAllReservations;

public class GetAllReservationsQuery : IRequest<List<ReservationDto>>
{

}
