using Application.CommonResponses;

namespace Application.UseCase.Author.Command.Create;

public class AuthorCreated : EntitySuccess<object>
{
    public AuthorCreated(bool success, object? body = null) : base(success, body)
    {
    }
}