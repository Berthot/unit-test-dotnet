using Domain.Exceptions.EntityFramework;
using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Extensions;
using MediatR;
// ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace Application.UseCase.Author.Query.GetAuthorById;

public class GetAuthorByIdHandler : IRequestHandler<GetAuthorQuery, GetAuthorResponse>
{
    private readonly IAuthorRepository _repo;

    public GetAuthorByIdHandler(IAuthorRepository repository)
    {
        _repo = repository.ThrowIfNull();
    }
    public async Task<GetAuthorResponse> Handle(GetAuthorQuery query, CancellationToken cancellationToken)
    {
        var entity = await _repo.GetByIdAsync(query.Id.ToGuid());
        NotFoundException.When(entity == default, "Author was not found");

        return new GetAuthorResponse(true, entity!.AuthorMap());
    }
}