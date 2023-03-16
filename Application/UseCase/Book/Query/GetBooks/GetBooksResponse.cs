using Domain.Models;

namespace Application.UseCase.Book.Query.GetBooks;

public class GetBooksResponse
{
    public List<BookDto> Data { get; set; } = new();
}