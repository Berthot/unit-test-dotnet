using System.Data;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.EntityFramework;

public class Context : DbContext, IUnitOfWork, IContext
{
    public Context()
    {
    }

    public Context(DbContextOptions builderOptions) : base(builderOptions)
    {
    }

    public IDbConnection Connection => base.Database.GetDbConnection();
    private IDbContextTransaction _currentTransaction = null!;
    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging(true)
            .EnableDetailedErrors(true)
            .UseNpgsql("Host=localhost;Port=5432;Username=myp;Password=batata123;Database=store;");
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }

    public void Commit()
    {
        base.SaveChanges();
    }

    public async Task<IDbContextTransaction> RollBack()
    {
        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        return _currentTransaction;
    }
}