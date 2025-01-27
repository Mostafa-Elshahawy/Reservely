﻿using MediatR;
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
[Authorize(Roles = "Admin")]
[Route("api/flights")]
public class FlightController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFlight(CreateFlightCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<FlightDto?>> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetFlightByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<FlightDto>>> GetAll([FromQuery] GetAllFlightsQuery query)
    {
        var flights = await mediator.Send(query);
        return Ok(flights);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await mediator.Send(new DeleteFlightCommand(id));
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateFlightCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
}
