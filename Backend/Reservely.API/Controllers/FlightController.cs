using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Flights.Commands.CreateFlight;
using Reserverly.Application.Flights.Commands.DeleteFlight;
using Reserverly.Application.Flights.Commands.UpdateFlight;
using Reserverly.Application.Flights.Dtos;
using Reserverly.Application.Flights.Queries.GetAllFlights;
using Reserverly.Application.Flights.Queries.GetFlightById;

namespace Reservely.API.Controllers;

[ApiController]
//[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class FlightController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateFlightCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("get/{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<FlightDto?>> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetFlightByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpGet("all")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<FlightDto>>> GetAll([FromQuery] GetAllFlightsQuery query)
    {
        var flights = await mediator.Send(query);
        return Ok(flights);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await mediator.Send(new DeleteFlightCommand(id));
        return NoContent();
    }

    [HttpPatch("update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateFlightCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
}
