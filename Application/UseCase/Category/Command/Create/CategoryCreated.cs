using Application.CommonResponses;

namespace Application.UseCase.Category.Command.Create;

public class CategoryCreated : EntitySuccess<string>
{
    public CategoryCreated(bool success, string? body) : base(success, body)
    {
    }
}