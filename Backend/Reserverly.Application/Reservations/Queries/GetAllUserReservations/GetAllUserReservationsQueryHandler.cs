﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Reservations.Dto;
using Reserverly.Application.Users;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Queries.GetAllUserReservations;

public class GetAllUserReservationsQueryHandler(IMapper mapper,ILogger<GetAllUserReservationsQueryHandler> logger ,
                                            IReservationRepository reservationRepository, IUserContext userContext)
                                            :IRequestHandler<GetAllUserReservationsQuery, IEnumerable<ReservationDto>>
{
    public async Task<IEnumerable<ReservationDto>> Handle(GetAllUserReservationsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all reservations for user {UserId}", request.UserId);
        var user = userContext.GetCurrentUser();
        if (user == null)
        {
            throw new UnauthorizedAccessException("User is not authenticated");
        }
        var reservations = await reservationRepository.GetAllByUserId();
        var reservationsDtos = mapper.Map<IEnumerable<ReservationDto>>(reservations);
        return reservationsDtos;
    }
}
