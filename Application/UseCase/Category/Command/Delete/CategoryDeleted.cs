using Application.CommonResponses;

namespace Application.UseCase.Category.Command.Delete;

public class CategoryDeleted : EntitySuccess<object>
{
    public CategoryDeleted(bool success, object? body = default(object)) : base(success, body)
    {
    }
}