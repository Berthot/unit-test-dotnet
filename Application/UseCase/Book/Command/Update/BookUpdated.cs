using Application.CommonResponses;

namespace Application.UseCase.Book.Command.Update;

public class BookUpdated : EntitySuccess<object>
{
    public BookUpdated(bool success, object? body = default(object)) : base(success, body)
    {
    }
}