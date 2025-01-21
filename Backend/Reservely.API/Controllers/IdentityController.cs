using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Reservely.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{

}
