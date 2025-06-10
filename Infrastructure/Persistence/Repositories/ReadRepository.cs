using System.Linq.Expressions;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
{
    private readonly DbSet<T> _entity;
    public ReadRepository(DbContext dbContext) => _entity = dbContext.Set<T>();
    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate) => await _entity.FirstOrDefaultAsync(predicate);
    public async Task<List<T>> GetAllAsync() => await _entity.ToListAsync();
    public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate) => await _entity.Where(predicate).ToListAsync();
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await _entity.AnyAsync(predicate);
    public IQueryable<T> Query() => _entity.AsQueryable();
}
