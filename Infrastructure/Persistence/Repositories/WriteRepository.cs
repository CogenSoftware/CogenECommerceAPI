using Core.Application.Interfaces.Repositories;
using Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _entity;

    public WriteRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _entity = _dbContext.Set<T>();
    }

    public async Task AddAsync(T entity) => await _entity.AddAsync(entity);
    public async Task AddRangeAsync(List<T> entities) => await _entity.AddRangeAsync(entities);
    public void Update(T entity) => _entity.Update(entity);
    public void HardRemove(T entity) => _entity.Remove(entity);
    public void HardRemoveRange(List<T> entities) => _entity.RemoveRange(entities);
    public void SoftRemove(T entity)
    {
        entity.IsDeleted = true;
        entity.UpdatedAt = DateTime.UtcNow;
        _entity.Update(entity);
    }
    public void SoftRemoveRange(List<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
        }
        _entity.UpdateRange(entities);
    }
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
