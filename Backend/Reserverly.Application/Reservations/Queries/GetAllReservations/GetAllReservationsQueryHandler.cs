using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Reservations.Dto;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Queries.GetAllReservations;

public class GetAllReservationsQueryHandler(ILogger<GetAllReservationsQueryHandler> logger, IMapper mapper, IReservationRepository reservationRepository)
                    : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
{
    public async Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all reservations");
        var reservations = await reservationRepository.GetAll();
        if (reservations == null)
        {
            logger.LogWarning("No reservations found");
            return new List<ReservationDto>();
        }
        var reservationsDtos = mapper.Map<List<ReservationDto>>(reservations);
        return reservationsDtos.ToList();
    }
}
