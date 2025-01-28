using MediatR;

namespace Reserverly.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
{
    public Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
