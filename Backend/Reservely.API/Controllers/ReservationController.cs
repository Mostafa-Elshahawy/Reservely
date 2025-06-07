using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reserverly.Application.Reservations.Dto;
using Reserverly.Application.Reservations.Queries.GetAllReservations;
using Reserverly.Application.Reservations.Queries.GetReservationById;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class ReservationController(IMediator mediator) : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<List<ReservationDto>>> GetAll()
    {
        var query = new GetAllReservationsQuery();
        var reservations = await mediator.Send(query);
        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto?>> GetById([FromRoute] int reservationId, [FromRoute] string userId)
    {
        var reservation = await mediator.Send(new GetReservationByIdQuery(reservationId, userId));
        return Ok(reservation);
    }
}
