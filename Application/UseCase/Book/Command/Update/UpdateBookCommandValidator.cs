using FluentValidation;

namespace Application.UseCase.Book.Command.Update;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        
    }
}