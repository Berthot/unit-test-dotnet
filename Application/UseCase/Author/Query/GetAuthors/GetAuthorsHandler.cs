using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Author.Query.GetAuthors;

public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, GetAuthorsResponse>
{
    private readonly IAuthorRepository _repo;
    public GetAuthorsHandler(IAuthorRepository repository)
    {
        _repo = repository.ThrowIfNull();
    }
    public async Task<GetAuthorsResponse> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repo.GetAllAsync();

        return new GetAuthorsResponse()
        {
            Data = entities.Select(x => x.AuthorMap()).ToList()
        };

    }
}