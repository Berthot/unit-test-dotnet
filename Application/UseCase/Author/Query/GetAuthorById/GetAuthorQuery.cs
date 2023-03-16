using MediatR;

namespace Application.UseCase.Author.Query.GetAuthorById;

public class GetAuthorQuery : IRequest<GetAuthorResponse>
{
    public string Id { get; set; } = null!;
}