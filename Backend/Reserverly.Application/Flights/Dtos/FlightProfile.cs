using AutoMapper;
using Reserverly.Application.Flights.Commands.CreateFlight;
using Reserverly.Domain.Entities;

namespace Reserverly.Application.Flights.Dtos;

public class FlightProfile : Profile
{
    public FlightProfile()
    {
        CreateMap<Flight, FlightDto>();
        CreateMap<CreateFlightCommand, Flight>();
    }
}
