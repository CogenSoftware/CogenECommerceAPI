using Core.Application.Bases;
using Core.Application.Features.Brand.Rules;
using Core.Application.Interfaces.AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Features.Brand.Commands.SoftDelete;

public class BrandSoftDeleteHandler : BaseHandler, IRequestHandler<BrandSoftDeleteRequest, Unit>
{
    private readonly BrandRules _brandRules;
    public BrandSoftDeleteHandler(
        BrandRules brandRules,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) :
        base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<Unit> Handle(BrandSoftDeleteRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Brand? brand = await _unitOfWork.GetReadRepository<Domain.Entities.Brand>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
        await _brandRules.BrandNotFoundRule(brand);
        brand!.IsDeleted = true;
        brand!.UpdatedAt = DateTime.UtcNow.AddHours(3);
        await _unitOfWork.GetWriteRepository<Domain.Entities.Brand>().SoftRemoveAsync(brand);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}