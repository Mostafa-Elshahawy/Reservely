using MediatR;
using Reserverly.Application.Flights.Dtos;

namespace Reserverly.Application.Flights.Queries.GetFlightById;

public class GetFlightByIdQuery(int id) : IRequest<FlightDto?>
{
    public int Id { get; set; } = id;
}
