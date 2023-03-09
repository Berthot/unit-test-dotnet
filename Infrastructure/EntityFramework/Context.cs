using System.Data;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.EntityFramework;

public class Context : DbContext, IUnitOfWork, IContext
{
    public Context(DbContextOptions<Context> builderOptions) : base(builderOptions) { }
    public Context() { }
    
    public IDbConnection Connection => base.Database.GetDbConnection();
    private IDbContextTransaction _currentTransaction;
    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    
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