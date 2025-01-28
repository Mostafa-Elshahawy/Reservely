using MediatR;
using Reserverly.Application.Reservations.Dto;

namespace Reserverly.Application.Reservations.Queries.GetReservationById;

public class GetReservationByIdQuery(int id) : IRequest<ReservationDto>
{
    public int Id { get; } = id;
}
