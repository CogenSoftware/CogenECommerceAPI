
using Core.Application.Interfaces.Repositories;
using Core.Application.Interfaces.UnitOfWorks;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class Registration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        serviceCollection.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        return serviceCollection;
    }
}
