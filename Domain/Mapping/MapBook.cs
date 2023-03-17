using Domain.Entities;
using Domain.Models;

namespace Domain.Mapping;

public static class MapBook
{
    public static BookDto BookMap(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Url = book.Url,
            Price = book.Price,
            CreatedAt = book.CreatedAt,
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId,
        };
    }

    public static Book BookMap(this BookDto book)
    {
        return new Book
        {
            Id = book.Id,
            Title = book.Title,
            Url = book.Url,
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId,
        };
    }
}