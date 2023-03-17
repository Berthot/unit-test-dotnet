using Infrastructure.EntityFramework;
using NUnit.Framework;
using UnitTestCommon.Base.Db;
using UnitTestCommon.Seeds;

namespace UnitTestCommon.Base;

public class UnitTestBase : DbContextInDocker<Context>
{

    protected Context Context = null!;
    
    [OneTimeSetUp]
    public void SetUp()
    {
        Context = CreateContext();

        Context.Authors.Add(AuthorSeed.GetAuthor(1, "Robert C. Martin"));
        Context.Categories.Add(CategorySeed.GetCategory(1, "Technology"));
        Context.SaveChanges();
    }
}