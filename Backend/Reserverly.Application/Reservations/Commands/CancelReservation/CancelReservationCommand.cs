using MediatR;

namespace Reserverly.Application.Reservations.Commands.UpdateReservation;

public record CancelReservationCommand(int ReservationId) : IRequest<int>
{
}
