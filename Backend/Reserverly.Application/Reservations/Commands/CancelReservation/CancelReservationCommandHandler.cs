using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Interfaces;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Commands.UpdateReservation;

public class CancelReservationCommandHandler(IReservationRepository reservationRepository,
                    IReservationAuthorizationService reservationAuthorizationService,
                    ILogger<CancelReservationCommandHandler> logger) : IRequestHandler<CancelReservationCommand, int>
{
    public async Task<int> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Cancelling reservation {request.ReservationId}");
        var reservation = await reservationRepository.GetById(request.ReservationId);
        if (reservation == null)
        {
            throw new NotFoundException(nameof(Reservation), request.ReservationId.ToString());
        }

        if (!reservationAuthorizationService.Authorize(reservation, ResourceOperation.Delete))
        {
            throw new UnauthorizedAccessException();
        }

        var flightClass = reservation.Flight.FlightClasses
       .FirstOrDefault(fc => fc.ClassType == reservation.FlightClassType);

        if (flightClass != null)
            flightClass.AvailableSeats += reservation.NumberOfSeats;

        reservation.ReservationStatus = ReservationStatus.Cancelled;
        await reservationRepository.Update(reservation);
        return reservation.Id;
    }
}
