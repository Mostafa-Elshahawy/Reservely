using FluentValidation;

namespace Reserverly.Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        RuleFor(x => x.Airline).NotEmpty();
        RuleFor(x => x.FlightNumber).NotEmpty();
        RuleFor(x => x.AvailableSeats).GreaterThan(0);
        RuleFor(x => x.DepartureLounge).NotEmpty();
        RuleFor(x => x.ArrivalLounge).NotEmpty();
        RuleFor(x => x.DepartureTime).NotEmpty();
        RuleFor(x => x.ArrivalTime).NotEmpty();
        RuleFor(x => x.DepartureAirportId).GreaterThan(0);
        RuleFor(x => x.ArrivalAirportId).GreaterThan(0);
        RuleFor(x => x.ClassPricingId).GreaterThan(0);
    }
}
