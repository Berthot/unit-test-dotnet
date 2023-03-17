namespace Domain.Models;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public double Price { get; set; }
}