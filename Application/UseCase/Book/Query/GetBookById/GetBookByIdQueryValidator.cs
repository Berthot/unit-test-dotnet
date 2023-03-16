using FluentValidation;

namespace Application.UseCase.Book.Query.GetBookById;

public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(x=>x.Id).NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The Value for 'Id' must be a Valid Guid.");
    }
}