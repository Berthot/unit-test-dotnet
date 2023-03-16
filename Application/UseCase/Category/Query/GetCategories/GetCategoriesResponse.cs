using Domain.Models;

namespace Application.UseCase.Category.Query.GetCategories;

public class GetCategoriesResponse
{
    public List<BookDto> Data { get; set; } = new();
}