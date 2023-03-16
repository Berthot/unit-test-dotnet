using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Author.Command.Create;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, AuthorCreated>
{
    private readonly IAuthorRepository _repo;

    public CreateAuthorHandler(IAuthorRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<AuthorCreated> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var entity = MapToEntity(command);

        await _repo.CreateAsync(entity);

        return new AuthorCreated(true, "");
    }

    private Domain.Entities.Author MapToEntity(CreateAuthorCommand command)
    {
        return new Domain.Entities.Author()
        {
            Name = command.Name
        };
    }
}