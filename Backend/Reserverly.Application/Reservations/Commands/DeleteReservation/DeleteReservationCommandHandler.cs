using MediatR;

namespace Reserverly.Application.Reservations.Commands.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    public Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
