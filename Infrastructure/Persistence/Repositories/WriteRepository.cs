using Core.Application.Interfaces.Repositories;
using Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
{
    private readonly DbContext _dbContext;
    public WriteRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private DbSet<T> table => _dbContext.Set<T>();
}