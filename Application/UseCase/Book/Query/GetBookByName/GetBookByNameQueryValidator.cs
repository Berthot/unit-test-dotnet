using FluentValidation;

namespace Application.UseCase.Book.Query.GetBookByName;

public class GetBookByNameValidator : AbstractValidator<GetBookByNameQuery>
{
    public GetBookByNameValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}