using MediatR;

namespace Reserverly.Application.Reservations.Commands.UpdateReservation;

public class CancelReservationCommand : IRequest<int>
{
    public int ReservationId { get; set; }
}
