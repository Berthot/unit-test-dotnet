using MediatR;

namespace Application.UseCase.Book.Command.Delete;

public class DeleteBookCommand : IRequest<BookDeleted>
{
    public string Id { get; set; } = null!;
}