using FluentValidation;

namespace Application.UseCase.Category.Command.Delete;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x=>x.Id).NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The Value for 'Id' must be a Valid Guid.");
    }
}