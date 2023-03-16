using Bogus;
using Domain.Entities;
using UnitTestCommon.Extensions;

namespace UnitTestCommon.Seeds;

public static class AuthorSeed
{
    private static readonly Faker Faker = new Faker();

    public static List<Author> GetAuthors(int howMany = 3)
    {
        howMany++;
        var list = new List<Author>();
        for (var i = 1; i < howMany; i++)
        {
            list.Add(new Author()
            {
                Id = i.ToGuid(),
                Name = Faker.Name.FullName()
            });
        }
        return list;
    }

    public static Author GetAuthor(int id, string? name = null)
    {
        return new Author()
        {
            Id = id.ToGuid(),
            Name = name ?? Faker.Name.FullName()
        };
    }
}