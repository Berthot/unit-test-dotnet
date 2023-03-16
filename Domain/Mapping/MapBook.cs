using Domain.Entities;
using Domain.Models;

namespace Domain.Mapping;

public static class MapBook
{
    public static BookDto BookMap(this Book book)
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

    public static Book BookMap(this BookDto book)
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