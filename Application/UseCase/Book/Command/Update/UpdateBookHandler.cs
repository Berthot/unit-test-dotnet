using Domain.Exceptions.EntityFramework;
using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace Application.UseCase.Book.Command.Update;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BookUpdated>
{
    private readonly IBookRepository _repo;

    public UpdateBookHandler(IBookRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<BookUpdated> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        var book = await _repo.GetByIdAsync(command.Id);
        
        NotFoundException.When(book == default, "book not found");

        book!.Title = VerifyIfNeedUpdate(command.Title!, book.Title);
        book!.Url = VerifyIfNeedUpdate(command.Url!, book.Url);

        await _repo.UpdateAsync(book);

        return new BookUpdated(true);
    }

    private static string VerifyIfNeedUpdate(string newValue, string oldValue)
    {
        return newValue == null || newValue == oldValue ? oldValue : newValue;
    }
}