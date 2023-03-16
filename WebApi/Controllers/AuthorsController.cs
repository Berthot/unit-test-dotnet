using Application.UseCase.Author.Command.Create;
using Application.UseCase.Author.Command.Delete;
using Application.UseCase.Author.Command.Update;
using Application.UseCase.Author.Query.GetAuthorBooksById;
using Application.UseCase.Author.Query.GetAuthorById;
using Application.UseCase.Author.Query.GetAuthors;
using Application.UseCase.Book.Command.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Base;

namespace WebApi.Controllers;

public class AuthorsController : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookCreated))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<AuthorCreated> Create([FromBody] CreateAuthorCommand command, CancellationToken cToken)
    {
        return await Mediator.Send(command, cToken);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorUpdated))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<AuthorUpdated> Update([FromBody] UpdateAuthorCommand command, CancellationToken cToken)
    {
        return await Mediator.Send(command, cToken);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDeleted))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<AuthorDeleted> Delete([FromRoute] string id, CancellationToken cToken)
    {
        var command = new DeleteAuthorCommand() {Id = id};
        return await Mediator.Send(command, cToken);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAuthorResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetAuthorResponse> GetById([FromRoute] string id, CancellationToken cToken)
    {
        var command = new GetAuthorQuery() {Id = id};
        return await Mediator.Send(command, cToken);
    }
    
    [HttpGet("{id}/books")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAuthorBooksResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetAuthorBooksResponse> GetAuthorBooksById([FromRoute] string id, CancellationToken cToken)
    {
        var command = new GetAuthorBooksQuery() {Id = id};
        return await Mediator.Send(command, cToken);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAuthorsResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetAuthorsResponse> GetAll(CancellationToken cToken)
    {
        var command = new GetAuthorsQuery();
        return await Mediator.Send(command, cToken);
    }
}