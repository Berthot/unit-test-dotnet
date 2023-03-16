using Application.UseCase.Book.Command.Create;
using Application.UseCase.Book.Command.Delete;
using Application.UseCase.Book.Command.Update;
using Application.UseCase.Book.Query.GetBookById;
using Application.UseCase.Book.Query.GetBooks;
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

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookUpdated))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<BookUpdated> Update([FromBody] UpdateBookCommand command, CancellationToken cToken)
    {
        return await Mediator.Send(command, cToken);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDeleted))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<BookDeleted> Delete([FromRoute] string id, CancellationToken cToken)
    {
        var command = new DeleteBookCommand() {Id = id};
        return await Mediator.Send(command, cToken);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetBookResponse> GetById([FromRoute] string id, CancellationToken cToken)
    {
        var command = new GetBookByIdQuery() {Id = id};
        return await Mediator.Send(command, cToken);
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBooksResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetBooksResponse> GetAll(CancellationToken cToken)
    {
        var command = new GetBooksQuery();
        return await Mediator.Send(command, cToken);
    }
}