using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Category.Query.GetCategories;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesResponse>
{
    private readonly IBookRepository _repo;

    public GetCategoriesHandler(IBookRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<GetCategoriesResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repo.GetAllAsync();

        return new GetCategoriesResponse()
        {
            Data = entities.Select(x => x.BookMap()).ToList()
        };
    }
}