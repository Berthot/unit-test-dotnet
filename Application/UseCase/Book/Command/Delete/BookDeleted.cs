using Application.CommonResponses;

namespace Application.UseCase.Book.Command.Delete;

public class BookDeleted : EntitySuccess<object>
{
    public BookDeleted(bool success, object? body = default(object)) : base(success, body)
    {
    }
}