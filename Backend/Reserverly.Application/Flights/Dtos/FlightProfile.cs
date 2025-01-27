using AutoMapper;
using Reserverly.Application.Flights.Commands.CreateFlight;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Flights.Dtos;

public class FlightProfile : Profile
{
    public FlightProfile()
    {
        CreateMap<Flight, FlightDto>()
            .ForMember(m => m.DepartureAirport, opt =>
                opt.MapFrom(src=>src.DepartureAirport == null ? null : src.DepartureAirport.Name))
            .ForMember(m=>m.ArrivalAirport, opt=>
                opt.MapFrom(src=>src.ArrivalAirport == null ? null : src.ArrivalAirport.Name))
            .ForMember(m => m.DepartureCity, opt =>
                opt.MapFrom(src => src.DepartureAirport == null ? null : src.DepartureAirport.City))
            .ForMember(m => m.ArrivalCity, opt =>
                opt.MapFrom(src => src.ArrivalAirport == null ? null : src.ArrivalAirport.City))
            .ForMember(m => m.DepartureCountry, opt =>
                opt.MapFrom(src => src.DepartureAirport == null ? null : src.DepartureAirport.Country))
            .ForMember(m => m.ArrivalCountry, opt =>
                opt.MapFrom(src => src.ArrivalAirport == null ? null : src.ArrivalAirport.Country));

        CreateMap<CreateFlightCommand, Flight>();
    }
}
