using Application.CommonResponses;

namespace Application.UseCase.Book.Query.GetBookById;

public class GetBookResponse : EntitySuccess<object>
{
    public GetBookResponse(bool success, object? body = default(object)) : base(success, body)
    {
    }
}