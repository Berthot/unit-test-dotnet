using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Category.Command.Delete;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, CategoryDeleted>
{
    private readonly ICategoryRepository _repo;

    public DeleteCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }

    public async Task<CategoryDeleted> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(request.Id.ToGuid());

        return new CategoryDeleted(true);
    }
}