using MediatR;

namespace Application.UseCase.Author.Query.GetAuthorBooksById;

public class GetAuthorBooksQuery : IRequest<GetAuthorBooksResponse>
{
    public string Id { get; set; } = null!;
}