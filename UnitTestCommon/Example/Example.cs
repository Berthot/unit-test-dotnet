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
    public async Task DoesNotThrowException_ExecuteAsync_ReturnVoid()
    {
        var category = CategorySeed.GetCategory(1);
        await _repo.CreateAsync(category);
        var getAll = await _repo.GetAllAsync();
        foreach (var cat in getAll)
        {
            Console.WriteLine(cat.Id + " -- " + cat.Name);
        }

        var list = await _repo.GetAllAsync();
        Assert.AreEqual(1, list.Count);
    }
}