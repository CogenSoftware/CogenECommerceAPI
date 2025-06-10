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
    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => _entity.Update(entity));
        return entity;
    }
    public async Task HardRemoveAsync(T entity)
    {
        await Task.Run(() => _entity.Remove(entity));
    }
    public async Task HardRemoveRangeAsync(List<T> entities)
    {
        await Task.Run(() => _entity.RemoveRange(entities));
    }
    public async Task SoftRemoveAsync(T entity)
    {
        await Task.Run(() =>
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            _entity.Update(entity);
        });
    }
    public async Task SoftRemoveRangeAsync(List<T> entities)
    {
        await Task.Run(() =>
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
            }
            _entity.UpdateRange(entities);
        });
    }
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
