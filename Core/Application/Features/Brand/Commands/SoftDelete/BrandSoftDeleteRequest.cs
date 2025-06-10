using MediatR;

namespace Core.Application.Features.Brand.Commands.SoftDelete;

public class BrandSoftDeleteRequest : IRequest<Unit>
{
    public int Id { get; set; }
}