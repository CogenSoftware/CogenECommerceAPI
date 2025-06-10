using Core.Domain.Common;

namespace Core.Domain.Entities;

public class Brand : EntityBase
{
    public string Name { get; set; } = null!;
}