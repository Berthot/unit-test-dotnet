namespace Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; } = null!;
    public List<Book> Books { get; set; } = new();
}