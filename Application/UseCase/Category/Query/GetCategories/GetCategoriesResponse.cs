using Domain.Models;

namespace Application.UseCase.Category.Query.GetCategories;

public class GetCategoriesResponse
{
    public List<CategoryDto> Data { get; set; } = new();
}