using System.Linq.Expressions;

namespace Domain.Interfaces.Base;

public interface IRepository<TEntity> where TEntity : Entity
{
    public Task<List<TEntity>> GetAllAsync();
    public Task CreateAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(Guid id);
    public Task<TEntity> GetByIdAsync(Guid id);
    public Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
    public Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    public Task<TEntity> GetEntityWithRelatedData(Guid id, params Expression<Func<TEntity, object>>[] includes);


}