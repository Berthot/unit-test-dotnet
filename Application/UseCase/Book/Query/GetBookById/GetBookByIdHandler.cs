using Domain.Exceptions.EntityFramework;
using Domain.Interfaces;
using Domain.Mapping;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Book.Query.GetBookById;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, GetBookResponse>
{
    private readonly IBookRepository _repo;

    public GetBookByIdHandler(IBookRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<GetBookResponse> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        var entity = await _repo.GetEntityWithRelatedData(query.Id.ToGuid(), x => x.Author);
        NotFoundException.When(entity == default, "Book was not found");

        return new GetBookResponse(true, entity!.BookMap());
    }
}