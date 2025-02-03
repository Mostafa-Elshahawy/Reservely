using Reserverly.Domain.Entities;

namespace Reserverly.Application.Flights.Dtos;

public class FlightClassDto
{
    public FlightClassType ClassType { get; init; }
    public int TotalSeats { get; init; }
    public int AvailableSeats { get; init; }
    public decimal Price { get; init; }
}
