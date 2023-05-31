using Application.CommonResponses;

namespace Application.UseCase.Book.Query.GetBookByName;

public class GetBookByNameResponse : EntitySuccess<object>
{
    public GetBookByNameResponse(bool success, object? body = default(object)) : base(success, body)
    {
    }
}