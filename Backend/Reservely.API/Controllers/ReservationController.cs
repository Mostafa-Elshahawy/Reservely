using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Reservations.Commands.CreateReservation;
using Reserverly.Application.Reservations.Commands.UpdateReservation;
using Reserverly.Application.Reservations.Dto;
using Reserverly.Application.Reservations.Queries.GetAllReservations;
using Reserverly.Application.Reservations.Queries.GetReservationById;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateReservationCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAll([FromQuery] GetAllReservationsQuery query)
    {
        var reservations = await mediator.Send(query);
        return Ok(reservations);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<ReservationDto?>> GetById([FromRoute] int id)
    {
        var reservation = await mediator.Send(new GetReservationByIdQuery(id));
        return Ok(reservation);
    }

    [HttpPut("cancel/{id}")]
    public async Task<IActionResult> Cancel(CancelReservationCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}
