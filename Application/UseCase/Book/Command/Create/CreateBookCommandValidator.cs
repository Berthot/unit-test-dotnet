using FluentValidation;

namespace Application.UseCase.Book.Command.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(5);
    }
}