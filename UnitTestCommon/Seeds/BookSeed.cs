using Bogus;
using Domain.Entities;
using UnitTestCommon.Extensions;

namespace UnitTestCommon.Seeds;

public class BookSeed
{
    private static readonly Faker Faker = new Faker();

    public static List<Book> GetCategories(int howMany = 3)
    {
        howMany++;
        var list = new List<Book>();
        for (var i = 1; i < howMany; i++)
        {
            list.Add(new Book
            {
                Id = i.ToGuid(),
                Title = Faker.Commerce.ProductName(),
                Url = Faker.Internet.Url(),
                CreatedAt = DateTime.UtcNow,
                Price = (double) Faker.Finance.Amount(new decimal(20d), new decimal(600d)),
                AuthorId = i.ToGuid(),
                CategoryId = i.ToGuid(),
            });
        }

        return list;
    }

    public static Book GetBook(int id, int authorId, int categoryId, string? title = null)
    {
        return new Book
        {
            Id = id.ToGuid(),
            Title = title ?? Faker.Commerce.ProductName(),
            Url = Faker.Internet.Url(),
            CreatedAt = DateTime.UtcNow,
            AuthorId = authorId.ToGuid(),
            Price = (double) Faker.Finance.Amount(new decimal(20d), new decimal(600d)),
            CategoryId = categoryId.ToGuid(),
        };
    }
}