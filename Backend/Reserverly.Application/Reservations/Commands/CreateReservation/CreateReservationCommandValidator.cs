using FluentValidation;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    private readonly IFlightRepository _flightRepository;
    public CreateReservationCommandValidator(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;

        RuleFor(x => x.NumberOfSeats)
           .GreaterThan(0)
           .WithMessage("Number of seats must be at least 1");

        RuleFor(x => x.FlightId)
            .MustAsync(FlightExistsAndIsAvailable)
            .WithMessage("Flight does not exist or is no longer available");

        RuleFor(x => x)
            .MustAsync(HaveSufficientSeats)
            .WithMessage("Not enough seats available in the selected class");

        RuleFor(x => x)
            .MustAsync(ReservationTimeValid)
            .WithMessage("Reservation must be made at least 4 hours before departure");
    }

    private async Task<bool> FlightExistsAndIsAvailable(int flightId, CancellationToken ct)
    {
        var flight = await _flightRepository.GetById(flightId);
        return flight != null &&
               flight.Status == FlightStatus.Scheduled &&
               flight.DepartureTime > DateTime.UtcNow;
    }

    private async Task<bool> HaveSufficientSeats(CreateReservationCommand command, CancellationToken ct)
    {
        var flight = await _flightRepository.GetById(command.FlightId);
        var flightClass = flight?.FlightClasses.FirstOrDefault(fc => fc.ClassType == command.FlightClassType);
        return flightClass != null && flightClass.AvailableSeats >= command.NumberOfSeats;
    }

    private async Task<bool> ReservationTimeValid(CreateReservationCommand command, CancellationToken ct)
    {
        var flight = await _flightRepository.GetById(command.FlightId);
        return flight != null &&
               flight.DepartureTime > DateTime.UtcNow.AddHours(4);
    }
}
