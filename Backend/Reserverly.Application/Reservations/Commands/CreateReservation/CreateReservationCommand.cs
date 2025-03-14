﻿using MediatR;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommand : IRequest<int>
{
    public string UserId { get; set; } = default!;
    public int NumberOfSeats { get; set; }
    public int FlightId { get; set; }
    public FlightClassType FlightClassType { get; set; }
}
