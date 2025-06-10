using Core.Domain.Common;

namespace Core.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    Task<T> UpdateAsync(T entity);
    Task HardRemoveAsync(T entity);
    Task HardRemoveRangeAsync(List<T> entities);
    Task SoftRemoveAsync(T entity);
    Task SoftRemoveRangeAsync(List<T> entities);
    Task<int> SaveChangesAsync();
}
