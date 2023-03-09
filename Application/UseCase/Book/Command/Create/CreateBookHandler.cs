using MediatR;

namespace Application.UseCase.Book.Command.Create;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookCreated>
{
    public async Task<BookCreated> Handle(CreateBookCommand command, CancellationToken cToken)
    {
        await Task.Delay(0, cToken);

        return new BookCreated();
    }
}