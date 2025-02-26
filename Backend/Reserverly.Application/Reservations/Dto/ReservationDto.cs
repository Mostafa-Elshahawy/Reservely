﻿using Reserverly.Application.Flights.Dtos;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Reservations.Dto;

public class ReservationDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int NumberOfSeats { get; set; }
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public FlightDto flight { get; set; } = default!;
    public FlightClassType FlightClassType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
