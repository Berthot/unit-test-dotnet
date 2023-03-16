using Application.CommonResponses;
using Domain.Models;

namespace Application.UseCase.Author.Query.GetAuthorById;

public class GetAuthorResponse : EntitySuccess<AuthorDto>
{
    public GetAuthorResponse(bool success, AuthorDto? body = default(AuthorDto)) : base(success, body)
    {
    }
}