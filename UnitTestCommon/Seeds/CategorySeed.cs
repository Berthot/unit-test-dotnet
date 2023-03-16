using Bogus;
using Domain.Entities;
using UnitTestCommon.Extensions;

namespace UnitTestCommon.Seeds;

public static class CategorySeed
{
    private static readonly Faker Faker = new Faker();

    public static List<Category> GetCategories(int howMany = 3)
    {
        howMany++;
        var list = new List<Category>();
        for (var i = 1; i < howMany; i++)
        {
            list.Add(new Category()
            {
                Id = i.ToGuid(),
                Name = Faker.Commerce.Department()
            });
        }
        return list;
    }

    public static Category GetCategory(int id, string? name = null)
    {
        return new Category()
        {
            Id = id.ToGuid(),
            Name = name ?? Faker.Name.FullName()
        };
    }
}