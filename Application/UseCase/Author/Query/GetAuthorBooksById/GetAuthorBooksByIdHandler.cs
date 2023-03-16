using Domain.Exceptions.EntityFramework;
using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Author.Query.GetAuthorBooksById;

public class GetAuthorBooksByIdHandler : IRequestHandler<GetAuthorBooksQuery, GetAuthorBooksResponse>
{
    private readonly IAuthorRepository _repo;
    public GetAuthorBooksByIdHandler(IAuthorRepository repository)
    {
        _repo = repository.ThrowIfNull();
    }
    public async Task<GetAuthorBooksResponse> Handle(GetAuthorBooksQuery query, CancellationToken cancellationToken)
    {
        var entity = await _repo.GetAuthorWithBooks(query.Id.ToGuid());
        
        NotFoundException.When(entity == default, "Author was not found");
        
        return new GetAuthorBooksResponse
        {
            Data = entity!.Books.Select(x=>x.BookMap()).ToList()
        };
    }


}