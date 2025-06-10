using Core.Application.Interfaces.Repositories;
using Core.Application.Interfaces.UnitOfWorks;
using Core.Domain.Common;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new() => new ReadRepository<T>(_appDbContext);

    public IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new() => new WriteRepository<T>(_appDbContext);

    public async Task<int> SaveAsync() => await _appDbContext.SaveChangesAsync();

    public int Save() => _appDbContext.SaveChanges();
    public async ValueTask DisposeAsync()
    {
        if (_appDbContext != null)
            await _appDbContext.DisposeAsync();
    }
}