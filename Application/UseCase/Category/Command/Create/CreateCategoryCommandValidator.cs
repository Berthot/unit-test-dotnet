using FluentValidation;

namespace Application.UseCase.Category.Command.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3);
    }
}