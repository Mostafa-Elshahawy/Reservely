using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Flights.Commands.CreateFlight;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Application.Flights.Queries.GetAllFlights;
using Reserverly.Application.Flights.Queries.GetFlightById;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/flight")]
public class FlightController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFlight(CreateFlightCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FlightDto?>> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetFlightByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlightDto>>> GetAll()
    {
        var flights = await mediator.Send(new GetAllFlightsQuery());
        return Ok(flights);
    }
}
