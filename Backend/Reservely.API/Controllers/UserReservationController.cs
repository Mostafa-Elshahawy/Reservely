using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Reservations.Commands.CreateReservation;
using Reserverly.Application.Reservations.Commands.UpdateReservation;
using Reserverly.Application.Reservations.Dto;
using Reserverly.Application.Reservations.Queries.GetAllUserReservations;
using Reserverly.Application.Reservations.Queries.GetReservationById;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/user/{userId}/[controller]")]
[Authorize(Roles = "User")]
public class UserReservationController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromRoute]string userId, CreateReservationCommand command)
    {
        command.UserId = userId;

        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAll([FromRoute]string userId)
    {
        var reservations = await mediator.Send(new GetAllUserReservationsQuery(userId));
        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto?>> GetById([FromRoute] int reservationId, [FromRoute]string userId)
    {
        var reservation = await mediator.Send(new GetReservationByIdQuery(reservationId,userId));
        return Ok(reservation);
    }

    [HttpPatch("cancel/{id}")]
    public async Task<IActionResult> Cancel([FromRoute] int id)
    {
        await mediator.Send(new CancelReservationCommand(id));
        return NoContent();
    }
}
