using FluentValidation;
using Reserverly.Application.Flights.Dtos;

namespace Reserverly.Application.Flights.Queries.GetAllFlights;

public class GetAllFlightsQueryValidator : AbstractValidator<GetAllFlightsQuery>
{
        private int[] PageSize = [10,20,30];
        private string[] AllowedFilteringColumns = [nameof(FlightDto.FlightNumber),
        nameof(FlightDto.Airline),nameof(FlightDto.DepartureCountry), nameof(FlightDto.ArrivalCountry)] ;

    public GetAllFlightsQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).Must(x => PageSize.Contains(x)).WithMessage($"PageSize must be one of the following: {string.Join(",", PageSize)}");
        RuleFor(x => x.SortBy).Must(x => AllowedFilteringColumns.Contains(x))
            .When(q => q.SortBy != null).WithMessage($"SortBy must be one of the following: {string.Join(",", AllowedFilteringColumns)}");
    }
}
