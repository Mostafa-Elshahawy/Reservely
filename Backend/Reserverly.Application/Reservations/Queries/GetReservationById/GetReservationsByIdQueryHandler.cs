using MediatR;
using Reserverly.Application.Reservations.Dto;

namespace Reserverly.Application.Reservations.Queries.GetReservationById;

public class GetReservationsByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
{
    public Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
