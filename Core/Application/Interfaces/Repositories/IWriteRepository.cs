using Core.Domain.Common;

namespace Core.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    void Update(T entity);
    void HardRemove(T entity);
    void HardRemoveRange(List<T> entities);
    void SoftRemove(T entity);
    void SoftRemoveRange(List<T> entities);
    Task<int> SaveChangesAsync();
}
