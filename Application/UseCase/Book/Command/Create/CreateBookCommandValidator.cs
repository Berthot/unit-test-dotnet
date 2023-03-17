using FluentValidation;

namespace Application.UseCase.Book.Command.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(5);
        RuleFor(x => x.Url).MinimumLength(5);
        RuleFor(x => x.Price).GreaterThan(0d);

        RuleFor(x => x.AuthorId).NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The Value for 'AuthorId' must be a Valid Guid.");

        RuleFor(x => x.CategoryId).NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The Value for 'CategoryId' must be a Valid Guid.");
    }
}