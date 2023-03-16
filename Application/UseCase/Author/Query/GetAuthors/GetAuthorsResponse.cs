using Domain.Models;

namespace Application.UseCase.Author.Query.GetAuthors;

public class GetAuthorsResponse
{
    public List<AuthorDto> Data { get; set; } = new();
}