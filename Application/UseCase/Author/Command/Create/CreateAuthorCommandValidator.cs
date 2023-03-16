using FluentValidation;

namespace Application.UseCase.Author.Command.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3);

    }
}