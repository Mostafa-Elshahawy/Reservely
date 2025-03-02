using AutoMapper;
using Reserverly.Application.Reservations.Commands.CreateReservation;
using Reserverly.Application.Reservations.Commands.UpdateReservation;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Reservations.Dto;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dest => dest.Airline, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.Airline : string.Empty))
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.FlightNumber : string.Empty))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.Status.ToString() : string.Empty))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.Duration.ToString(@"hh\:mm") : "00:00"))
            .ForMember(dest => dest.DepartureLounge, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.DepartureLounge : 0))
            .ForMember(dest => dest.ArrivalLounge, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.ArrivalLounge : 0))
            .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.DepartureTime : DateTime.MinValue))
            .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.ArrivalTime : DateTime.MinValue))
            .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.Flight.ArrivalAirport != null ? src.Flight.ArrivalAirport.Name : string.Empty))
            .ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.Flight.DepartureAirport != null ? src.Flight.DepartureAirport.Name : string.Empty))
            .ForMember(dest => dest.DepartureCity, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.DepartureCity : null))
            .ForMember(dest => dest.DepartureCountry, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.DepartureCountry : null))
            .ForMember(dest => dest.ArrivalCity, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.ArrivalCity : null))
            .ForMember(dest => dest.ArrivalCountry, opt => opt.MapFrom(src => src.Flight != null ? src.Flight.ArrivalCountry : null));

        CreateMap<CreateReservationCommand, Reservation>();

        CreateMap<CancelReservationCommand, Reservation>();
       
    }
}
