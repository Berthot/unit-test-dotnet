using Application.UseCase.Author.Command.Delete;
using FluentValidation;

namespace Application.UseCase.Author.Query.GetAuthorById;

public class GetAuthorQueryValidator : AbstractValidator<DeleteAuthorCommand>
{
    public GetAuthorQueryValidator()
    {
        RuleFor(x=>x.Id).NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The Value for 'Id' must be a Valid Guid.");
    }
}