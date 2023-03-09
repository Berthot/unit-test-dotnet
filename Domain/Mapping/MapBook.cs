using Domain.Entities;
using Domain.Models;

namespace Domain.Mapping;

public static class MapBook
{
    public static BookDto AuthorMap(this Book book)
    {
        return new BookDto
        {
            Title = book.Title,
            Url = book.Url,
            CreatedAt = book.CreatedAt,
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId,
        };
    }

    public static Book AuthorMap(this BookDto book)
    {
        return new Book
        {
            Title = book.Title,
            Url = book.Url,
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId,
        };
    }
}