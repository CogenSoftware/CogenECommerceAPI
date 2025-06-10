using Core.Application.Bases;
using Core.Application.Features.Brand.Rules;
using Core.Application.Interfaces.AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Features.Brand.Commands.Create;

public class Handler : BaseHandler, IRequestHandler<Request, Unit>
{
    private readonly BrandRules _brandRules;
    public Handler(
        BrandRules brandRules,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) :
        base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
    {
        IList<Domain.Entities.Brand> brands = await _unitOfWork.GetReadRepository<Domain.Entities.Brand>().GetAllAsync();
        await _brandRules.BrandNameMustBeUniqueRule(brands, request.Name);
        Domain.Entities.Brand brand = new(request.Name);
        await _unitOfWork.GetWriteRepository<Domain.Entities.Brand>().AddAsync(brand);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}