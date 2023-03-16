using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Book.Command.Create;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookCreated>
{
    private readonly IBookRepository _repo;

    public CreateBookHandler(IBookRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<BookCreated> Handle(CreateBookCommand command, CancellationToken cToken)
    {
        var entity = MapToEntity(command);
        entity.CreatedAt = DateTime.UtcNow;

        await _repo.CreateAsync(entity);

        return new BookCreated(true, "");
    }

    private static Domain.Entities.Book MapToEntity(CreateBookCommand command)
    {
        var entity = new Domain.Entities.Book();
        entity.Title = command.Title;
        entity.Url = command.Url;
        entity.AuthorId = command.AuthorId.ToGuid();
        entity.CategoryId = command.CategoryId.ToGuid();
        return entity;
    }
}