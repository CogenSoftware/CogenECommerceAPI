using Core.Domain.Common;

namespace Core.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(List<T> entities);
    Task<int> SaveChangesAsync();
}
