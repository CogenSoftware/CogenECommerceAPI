using System.Linq.Expressions;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
{
    private readonly DbSet<T> _entity;
    public ReadRepository(DbContext dbContext) => _entity = dbContext.Set<T>();
    public async Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = false)
    {
        IQueryable<T> query = _entity;

        if (!enableTracking)
            query = query.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        return await query.FirstOrDefaultAsync();
    }
    public async Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false
    )
    {
        IQueryable<T> query = _entity;

        if (!enableTracking)
            query = query.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        if (include != null)
            query = include(query);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }
}
