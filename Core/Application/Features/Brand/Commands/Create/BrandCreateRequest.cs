using MediatR;

namespace Core.Application.Features.Brand.Commands.Create;

public class BrandCreateRequest : IRequest<Unit>
{
    public string Name { get; set; } = null!;
}