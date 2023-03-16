using Application.CommonResponses;

namespace Application.UseCase.Author.Command.Delete;

public class AuthorDeleted : EntitySuccess<object>
{
    public AuthorDeleted(bool success, object? body = default(object)) : base(success, body)
    {
    }
}