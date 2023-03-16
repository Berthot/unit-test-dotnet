using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Book.Command.Delete;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, BookDeleted>
{
    private readonly IBookRepository _repo;

    public DeleteBookHandler(IBookRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }
    public async Task<BookDeleted> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(request.Id.ToGuid());

        return new BookDeleted(true);
    }
}