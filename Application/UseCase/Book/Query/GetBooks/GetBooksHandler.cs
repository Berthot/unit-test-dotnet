using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Book.Query.GetBooks;

public class GetBooksHandler : IRequestHandler<GetBooksQuery, GetBooksResponse>
{
    private readonly IBookRepository _repo;

    public GetBooksHandler(IBookRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<GetBooksResponse> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repo.GetAllAsync();

        return new GetBooksResponse()
        {
            Data = entities.Select(x => x.BookMap()).ToList()
        };
    }
}