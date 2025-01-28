using MediatR;
using Reserverly.Application.Reservations.Dto;

namespace Reserverly.Application.Reservations.Queries.GetAllReservations;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
{
    public Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
