namespace Domain.Entities;

public class Author : Entity
{
    public string Name { get; set; } = "";
    public virtual List<Book> Books { get; set; } = new();

    public double AveragePricePerBook()
    {
        if (Books.Count == 0) return 0.0;

        var totalPrices = Books.Sum(b => b.Price);
        
        return totalPrices / Books.Count;
    }
}