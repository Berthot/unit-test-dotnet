using MediatR;

namespace Application.UseCase.Book.Command.Update;

public class UpdateBookCommand : IRequest<BookUpdated>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }
}