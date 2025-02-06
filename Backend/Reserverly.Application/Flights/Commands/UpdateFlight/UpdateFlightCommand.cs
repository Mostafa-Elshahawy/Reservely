using MediatR;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Flights.Commands.UpdateFlight;

public class UpdateFlightCommand : IRequest
{
    public int Id { get; set; }
    public int DepartureLounge { get; set; }
    public int ArrivalLounge { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public FlightStatus Status { get; set; }
    public List<FlightClassDto> FlightClasses { get; set; } = new List<FlightClassDto>();
}
