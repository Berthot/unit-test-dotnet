using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Author.Command.Delete;

public class AuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, AuthorDeleted>
{
    private readonly IAuthorRepository _repo;

    public AuthorCommandHandler(IAuthorRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }
    public async Task<AuthorDeleted> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(request.Id.ToGuid());

        return new AuthorDeleted(true);
    }
}