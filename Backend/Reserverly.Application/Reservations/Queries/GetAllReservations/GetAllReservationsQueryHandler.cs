using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Reservations.Dto;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Queries.GetAllReservations;

public class GetAllReservationsQueryHandler(ILogger<GetAllReservationsQueryHandler> logger, IMapper mapper, IReservationRepository reservationRepository)
                    : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
{
    public Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all reservations");
        var reservations = reservationRepository.GetAll();
        var reservationsDtos = mapper.Map<IEnumerable<ReservationDto>>(reservations);
        return Task.FromResult(reservationsDtos.ToList());
    }
}
