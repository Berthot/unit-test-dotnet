namespace Domain.Interfaces.Base;

public interface IRepository<TEntity> where TEntity : Entity
{
    public Task<List<TEntity>> GetAllAsync();
    public Task CreateAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(Guid id);
    public Task<TEntity> GetByIdAsync(Guid id);
}