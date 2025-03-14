﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Reservations.Dto;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Queries.GetReservationById;

public class GetReservationsByIdQueryHandler(ILogger<GetReservationsByIdQueryHandler> logger, IMapper mapper, IReservationRepository reservationRepository)
                                        : IRequestHandler<GetReservationByIdQuery, ReservationDto>
{
    public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting reservation with id {request.ReservationId}");
        var reservation = await reservationRepository.GetById(request.ReservationId) ?? throw new NotFoundException(nameof(Reservation),request.ReservationId.ToString()) ;
        var reservationDto = mapper.Map<ReservationDto>(reservation);
        return (reservationDto);
    }
}
