using System.Linq.Expressions;
using Core.Domain.Common;

namespace Core.Application.Interfaces.Repositories;

public interface IReadRepository<T> where T : class, IEntityBase, new()
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> Query();
}