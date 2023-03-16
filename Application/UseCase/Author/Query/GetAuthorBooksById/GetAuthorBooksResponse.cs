using Domain.Models;

namespace Application.UseCase.Author.Query.GetAuthorBooksById;

public class GetAuthorBooksResponse
{
    public List<BookDto> Data { get; set; } = new();
}