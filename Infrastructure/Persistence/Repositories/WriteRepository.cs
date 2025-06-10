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
    public void Remove(T entity) => _entity.Remove(entity);
    public void RemoveRange(List<T> entities) => _entity.RemoveRange(entities);
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
