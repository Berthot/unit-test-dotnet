using Domain.Interfaces;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories;
using NUnit.Framework;
using UnitTestCommon.Base.Db;
using UnitTestCommon.Seeds;

namespace UnitTestCommon.Example;

public class Example : DbContextInDocker<Context>
{
    private readonly ICategoryRepository _repo;
    private readonly Context _context;

    public Example()
    {
        _context = CreateContext();
        _repo = new CategoryRepository(_context);
    }
    
    
    [Test]
    public void DoesNotThrowException_ExecuteAsync_ReturnVoid()
    {
        var category = CategorySeed.GetCategory(1);
        _repo.CreateAsync(category);
        foreach (var cat in _context.Categories.ToList())
        {
            Console.WriteLine(cat.Id + " -- " + cat.Name);
        }
        Assert.AreEqual(1, _context.Categories.Count());
    }
}