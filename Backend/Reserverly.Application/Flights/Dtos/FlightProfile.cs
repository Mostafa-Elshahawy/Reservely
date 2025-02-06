using AutoMapper;
using Reserverly.Application.Flights.Commands.CreateFlight;
using Reserverly.Application.Flights.Commands.UpdateFlight;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Flights.Dtos;

public class FlightProfile : Profile
{
    public FlightProfile()
    {
        CreateMap<Flight, FlightDto>()
            .ForMember(m => m.DepartureAirport, src =>
                src.MapFrom(src => src.DepartureAirport == null ? null : src.DepartureAirport.Name))
            .ForMember(m => m.ArrivalAirport, src =>
                src.MapFrom(src => src.ArrivalAirport == null ? null : src.ArrivalAirport.Name))
            .ForMember(m => m.DepartureCity, src =>
                src.MapFrom(src => src.DepartureAirport == null ? null : src.DepartureAirport.City))
            .ForMember(m => m.ArrivalCity, src =>
                src.MapFrom(src => src.ArrivalAirport == null ? null : src.ArrivalAirport.City))
            .ForMember(m => m.DepartureCountry, src =>
                src.MapFrom(src => src.DepartureAirport == null ? null : src.DepartureAirport.Country))
            .ForMember(m => m.ArrivalCountry, src =>
                src.MapFrom(src => src.ArrivalAirport == null ? null : src.ArrivalAirport.Country))
            .ForMember(dest => dest.FlightClasses, src => 
                src.MapFrom(src => src.FlightClasses ?? new List<FlightClass>()));

        CreateMap<CreateFlightCommand, Flight>()
             .ForMember(dest => dest.FlightClasses,
                       opt => opt.MapFrom(src => src.FlightClasses));

        CreateMap<FlightClassDto, FlightClass>();

        CreateMap<FlightClass, FlightClassDto>();

        CreateMap<UpdateFlightCommand, Flight>()
             .BeforeMap((src, dest) =>
             {
                 if (src.DepartureLounge == default) src.DepartureLounge = dest.DepartureLounge;
                 if (src.ArrivalLounge == default) src.ArrivalLounge = dest.ArrivalLounge;
                 if (src.DepartureTime == default) src.DepartureTime = dest.DepartureTime;
                 if (src.ArrivalTime == default) src.ArrivalTime = dest.ArrivalTime;
                 if (src.Status == default) src.Status = dest.Status;
                 if (src.FlightClasses == null) src.FlightClasses = dest.FlightClasses.Select(fc => new FlightClassDto
                 {
                     ClassType = fc.ClassType,
                     TotalSeats = fc.TotalSeats,
                     AvailableSeats = fc.AvailableSeats,
                     Price = fc.Price
                 }).ToList();
             });
    }
}
