using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork
{
    public Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    void Commit();
    Task<IDbContextTransaction> RollBack();
}