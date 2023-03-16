using Application.CommonResponses;

namespace Application.UseCase.Book.Command.Create;

public class BookCreated : EntitySuccess<string>
{
    public BookCreated(bool success, string? body) : base(success, body)
    {
    }
}