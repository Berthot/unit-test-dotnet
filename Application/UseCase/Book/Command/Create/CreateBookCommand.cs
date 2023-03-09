using MediatR;

namespace Application.UseCase.Book.Command.Create;

public class CreateBookCommand : IRequest<BookCreated>
{
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
}