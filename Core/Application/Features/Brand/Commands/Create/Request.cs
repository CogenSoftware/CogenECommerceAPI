using MediatR;

namespace Core.Application.Features.Brand.Commands.Create;

public class Request : IRequest<Unit>
{
    public string Name { get; set; } = null!;
}