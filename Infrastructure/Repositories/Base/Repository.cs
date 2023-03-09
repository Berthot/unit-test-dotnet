using Domain.Entities.Base;
using Domain.Exceptions.EntityFramework;
using Domain.Interfaces.Base;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace Infrastructure.Repositories.Base;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _entities;

    protected Repository(DbContext context)
    {
        _context = context.ThrowIfNull();
        _entities = context.Set<TEntity>();
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return _entities.ToListAsync();
    }

    public async Task CreateAsync(TEntity entity)
    {
        DbRegisterExistsException.When(entity == null, "Entity is null");
        await _entities.AddAsync(entity!);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        UpdateFailureException.When(entity == null,"Entity is null");
        _entities.Update(entity!);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        DeleteFailureException.When(id == Guid.Empty, "Id is null");

        var entity = await GetByIdAsync(id);
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<TEntity> GetByIdAsync(Guid id)
    {
        return _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)!;
    }
}