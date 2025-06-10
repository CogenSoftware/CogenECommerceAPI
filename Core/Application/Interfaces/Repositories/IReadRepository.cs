using Core.Domain.Common;

namespace Core.Application.Interfaces.Repositories;

public interface IReadRepository<T> where T : class, IEntityBase, new()
{

}