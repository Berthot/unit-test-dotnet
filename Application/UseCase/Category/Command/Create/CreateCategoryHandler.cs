using Domain.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.UseCase.Category.Command.Create;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryCreated>
{
    private readonly ICategoryRepository _repo;

    public CreateCategoryHandler(ICategoryRepository repo)
    {
        _repo = repo.ThrowIfNull();
    }
    
    public async Task<CategoryCreated> Handle(CreateCategoryCommand command, CancellationToken cToken)
    {
        var entity = MapToEntity(command);

        await _repo.CreateAsync(entity);
        
        return new CategoryCreated(true, "");
    }

    private static Domain.Entities.Category MapToEntity(CreateCategoryCommand command)
    {
        return new Domain.Entities.Category
        {
            Name = command.Name,
        };
    }
}