using FluentValidation;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Commands.UpdateReservation;

public class CancelReservationCommandValidator : AbstractValidator<CancelReservationCommand>
{
    private readonly IReservationRepository _reservationRepository;
    public CancelReservationCommandValidator(IReservationRepository reservationRepository)
    {
        this._reservationRepository = reservationRepository;

        RuleFor(x => x.ReservationId)
              .NotEmpty()
              .MustAsync(ReservationExists)
              .WithMessage("Reservation does not exist")
              .MustAsync(ReservationNotAlreadyCancelled)
              .WithMessage("Reservation is already cancelled")
              .MustAsync(FlightDepartureNotWithin24Hours)
              .WithMessage("Cancellation is not allowed within 24 hours of departure");
    }

    private async Task<bool> ReservationExists(int reservationId, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetById(reservationId);
        return reservation != null;
    }

    private async Task<bool> ReservationNotAlreadyCancelled(int reservationId, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetById(reservationId);
        return reservation?.ReservationStatus != ReservationStatus.Cancelled;
    }

    private async Task<bool> FlightDepartureNotWithin24Hours(int reservationId, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetById(reservationId);
        return reservation?.Flight.DepartureTime > DateTime.UtcNow.AddHours(24);
    }
}
