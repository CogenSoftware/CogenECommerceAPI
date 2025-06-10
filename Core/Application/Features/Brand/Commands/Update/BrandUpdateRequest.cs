using MediatR;

namespace Core.Application.Features.Brand.Commands.Update;

public class BrandUpdateRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}