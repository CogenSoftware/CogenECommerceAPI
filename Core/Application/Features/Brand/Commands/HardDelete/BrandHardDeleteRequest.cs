using MediatR;

namespace Core.Application.Features.Brand.Commands.HardDelete;

public class BrandHardDeleteRequest : IRequest<Unit>
{
    public int Id { get; set; }
}