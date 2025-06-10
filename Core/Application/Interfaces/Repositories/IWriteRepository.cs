using Core.Domain.Common;

namespace Core.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{

}