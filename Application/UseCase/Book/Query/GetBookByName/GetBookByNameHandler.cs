using Domain.Exceptions.EntityFramework;
using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Book.Query.GetBookByName;

public class GetBookByNameHandler : IRequestHandler<GetBookByNameQuery, GetBookByNameResponse>
{
    private readonly IBookRepository _repo;

    public GetBookByNameHandler(IBookRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<GetBookByNameResponse> Handle(GetBookByNameQuery query, CancellationToken cancellationToken)
    {
        var entity = await _repo.FirstOrDefault(x => x.Title == query.Title);
            
        NotFoundException.When(entity == default, "Book was not found");

        return new GetBookByNameResponse(true, entity!.BookMap());
    }
}