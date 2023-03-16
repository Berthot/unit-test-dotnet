using MediatR;


namespace Application.UseCase.Book.Command.Create;

public class CreateBookCommand : IRequest<BookCreated>
{
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string AuthorId { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
}