using MediatR;

namespace Application.UseCase.Author.Command.Create;

public class CreateAuthorCommand : IRequest<AuthorCreated>
{
    public string Name { get; set; } = null!;
}