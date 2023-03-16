using Microsoft.EntityFrameworkCore;

namespace UnitTestCommon.Base.Db;

public class DbContextInMemory<TContext> : IDisposable where TContext : DbContext
{
    protected const string ConnectionString = "Host=localhost;Database=TestDatabase;Username=postgres;Password=password";

    protected readonly DbContextOptions<TContext> Options;

    protected DbContextInMemory()
    {
        Options = new DbContextOptionsBuilder<TContext>()
            .UseNpgsql(ConnectionString, o => o.SetPostgresVersion(new Version(13, 0)))
            .Options;

        using var context = CreateContext();
        context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        using var context = CreateContext();
        context.Database.EnsureDeleted();
    }

    protected TContext CreateContext()
    {
        return (TContext)Activator.CreateInstance(typeof(TContext), Options);
    }
}