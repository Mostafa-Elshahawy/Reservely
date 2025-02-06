using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reserverly.Application.Users;
using Reserverly.Domain.Constants;
using Reserverly.Domain.Entities;
using Reserverly.Domain.Exceptions;
using Reserverly.Domain.Interfaces;
using Reserverly.Domain.Repositories;

namespace Reserverly.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandHandler(IMapper mapper, ILogger<CreateReservationCommandHandler> logger,
                                            IReservationRepository reservationRepository,
                                            IFlightRepository flightRepository,
                                            IReservationAuthorizationService reservationAuthorizationService,
                                            IUserContext userContext)
                                            : IRequestHandler<CreateReservationCommand, int>
{
    public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Creating a new reservation {request}");

        var user = userContext.GetCurrentUser();
        if (user == null) throw new UnauthorizedAccessException();

        var flight = await flightRepository.GetById(request.FlightId);
        if (flight == null) throw new NotFoundException(nameof(Flight), request.FlightId.ToString());

        if (flight.Status != FlightStatus.Scheduled)
            throw new Exception("Flight is not available");

        if (flight.DepartureTime <= DateTime.UtcNow.AddHours(4))
            throw new Exception("Reservation too close to departure");

        var flightClass = flight.FlightClasses
                    .FirstOrDefault(fc => fc.ClassType == request.FlightClassType);

        if (flightClass == null || flightClass.AvailableSeats < request.NumberOfSeats)
            throw new Exception("Not enough seats");

        var reservation = mapper.Map<Reservation>(request);
        reservation.UserId = user.Id;
        reservation.ReservationStatus = ReservationStatus.Pending;

        if (!reservationAuthorizationService.Authorize(reservation, ResourceOperation.Create))
        {
            throw new UnauthorizedAccessException();
        }
        flightClass.AvailableSeats -= request.NumberOfSeats;

        int id = await reservationRepository.Create(reservation);
        await flightRepository.Update(flight);
        return id;
    }
}
