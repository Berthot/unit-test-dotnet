using FluentValidation;

namespace Application.UseCase.Author.Command.Delete;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(x=>x.Id).NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The Value for 'Id' must be a Valid Guid.");
    }
}