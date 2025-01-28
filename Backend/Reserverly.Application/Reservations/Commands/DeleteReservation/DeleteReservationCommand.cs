using MediatR;

namespace Reserverly.Application.Reservations.Commands.DeleteReservation;

public class DeleteReservationCommand(int id) : IRequest
{
    public int Id { get;} = id;
}
