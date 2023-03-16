using MediatR;

namespace Application.UseCase.Category.Command.Create;

public class CreateCategoryCommand : IRequest<CategoryCreated>
{
    public string Name { get; set; } = null!;
}