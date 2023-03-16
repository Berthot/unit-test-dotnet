using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Author.Command.Update;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, AuthorUpdated>
{
    private readonly IAuthorRepository _repo;

    public UpdateAuthorHandler(IAuthorRepository repository)
    {
        _repo = repository.ThrowIfNull();
    }
    public async Task<AuthorUpdated> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = await _repo.GetByIdAsync(command.Id.ToGuid());

        author.Name = command.Name;

        await _repo.UpdateAsync(author);

        return new AuthorUpdated(true);
    }
}