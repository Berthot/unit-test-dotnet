using MediatR;

namespace Application.UseCase.Author.Command.Delete;

public class DeleteAuthorCommand : IRequest<AuthorDeleted>
{
    public string Id { get; set; } = null!;
}