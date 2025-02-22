using FluentValidation;
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
    }
}
