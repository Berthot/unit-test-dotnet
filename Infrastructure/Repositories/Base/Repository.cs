using System.Linq.Expressions;
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

    public async Task<TEntity> GetEntityWithRelatedData(Guid id, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return (await query.FirstOrDefaultAsync(x => x.Id == id))!;
    }


    public async Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.Where(predicate).ToListAsync();
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return _entities.ToListAsync();
    }

    public async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.FirstOrDefaultAsync(predicate);
    }


    public async Task CreateAsync(TEntity entity)
    {
        DbRegisterExistsException.When(entity == null, "Entity is null");
        await _entities.AddAsync(entity!);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        UpdateFailureException.When(entity == null, "Entity is null");
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