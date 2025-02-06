using AutoMapper;
using Reserverly.Application.Reservations.Commands.CreateReservation;
using Reserverly.Application.Reservations.Commands.UpdateReservation;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Reservations.Dto;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>();

        CreateMap<CreateReservationCommand, Reservation>();

        CreateMap<CancelReservationCommand, Reservation>().
            ForMember(d=>d.Id, m => m.MapFrom(m => m.ReservationId));
    }
}
