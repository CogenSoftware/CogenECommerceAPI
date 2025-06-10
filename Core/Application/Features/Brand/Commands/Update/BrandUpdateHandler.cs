using Core.Application.Bases;
using Core.Application.Features.Brand.Rules;
using Core.Application.Interfaces.AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Features.Brand.Commands.Update;

public class BrandUpdateHandler : BaseHandler, IRequestHandler<BrandUpdateRequest, Unit>
{
    private readonly BrandRules _brandRules;
    public BrandUpdateHandler(
        BrandRules brandRules,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) :
        base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<Unit> Handle(BrandUpdateRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Brand? brand = await _unitOfWork.GetReadRepository<Domain.Entities.Brand>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
        await _brandRules.BrandNotFoundRule(brand);
        IList<Domain.Entities.Brand> brands = await _unitOfWork.GetReadRepository<Domain.Entities.Brand>().GetAllAsync();
        await _brandRules.BrandNameMustBeUniqueRule(brands, request.Name, request.Id);
        var map = _mapper.Map<BrandUpdateRequest, Domain.Entities.Brand>(request);
        map.CreatedAt = brand!.CreatedAt;
        map.UpdatedAt = DateTime.UtcNow.AddHours(3);
        await _unitOfWork.GetWriteRepository<Domain.Entities.Brand>().UpdateAsync(map);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}