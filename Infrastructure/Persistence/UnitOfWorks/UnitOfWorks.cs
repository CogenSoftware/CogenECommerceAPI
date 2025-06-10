using Core.Application.Interfaces.UnitOfWorks;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.UnitOfWorks;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly AppDbContext _appDbContext;
    public UnitOfWorks(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async ValueTask DisposeAsync()
    {
        if (_appDbContext != null)
            await _appDbContext.DisposeAsync();
    }
}