using System.Linq.Expressions;
using Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Application.Interfaces.Repositories;

public interface IReadRepository<T> where T : class, IEntityBase, new()
{
    Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T,
        object>>? include = null,
        bool enableTracking = false
    );
    Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false
    );
}