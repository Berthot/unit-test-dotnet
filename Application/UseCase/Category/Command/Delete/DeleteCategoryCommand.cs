using MediatR;

namespace Application.UseCase.Category.Command.Delete;

public class DeleteCategoryCommand : IRequest<CategoryDeleted>
{
    public string Id { get; set; } = null!;
}