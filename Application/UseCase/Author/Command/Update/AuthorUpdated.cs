using Application.CommonResponses;

namespace Application.UseCase.Author.Command.Update;

public class AuthorUpdated: EntitySuccess<object>
{
    public AuthorUpdated(bool success, object? body = default(object)) : base(success, body)
    {
    }
}