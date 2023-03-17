namespace Domain.Entities;

public class Book : Entity
{
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public double Price { get; set; } = 0.0;
    public DateTime CreatedAt { get; set; }
    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}