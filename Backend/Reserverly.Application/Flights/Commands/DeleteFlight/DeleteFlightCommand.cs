using MediatR;

namespace Reserverly.Application.Flights.Commands.DeleteFlight;

public class DeleteFlightCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
