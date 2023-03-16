using Application.UseCase.Book.Command.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Base;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
public class BookController : ApiControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookCreated))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<BookCreated> Create([FromBody] CreateBookCommand command, CancellationToken cToken)
    {
        return await Mediator.Send(command, cToken);
    }
}