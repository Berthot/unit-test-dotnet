using Domain.Entities;
using Domain.Models;

namespace Domain.Mapping;

public static class MapAuthor
{
    public static AuthorDto AuthorMap(this Author author)
    {
        return new AuthorDto
        {
            Name = author.Name
        };
    }

    public static Author AuthorMap(this AuthorDto author)
    {
        return new Author
        {
            Name = author.Name,
        };
    }
}