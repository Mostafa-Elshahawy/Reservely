using MediatR;

namespace Reserverly.Application.Reservations.Commands.UpdateReservation;

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
{
    public Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
