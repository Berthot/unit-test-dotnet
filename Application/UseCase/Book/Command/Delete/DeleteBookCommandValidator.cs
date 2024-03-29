using FluentValidation;

namespace Application.UseCase.Book.Command.Delete;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x=>x.Id).NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The Value for 'Id' must be a Valid Guid.");
    }
}