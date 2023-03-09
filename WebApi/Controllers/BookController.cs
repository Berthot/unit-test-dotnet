using Application.UseCase.Book.Command.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class BookController : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookCreated))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateBookCommand command, CancellationToken cToken)
    {
        return Ok(await Mediator.Send(command, cToken));
    }
}