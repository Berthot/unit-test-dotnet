using MediatR;

namespace Application.UseCase.Author.Command.Update;

public class UpdateAuthorCommand : IRequest<AuthorUpdated>
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
}