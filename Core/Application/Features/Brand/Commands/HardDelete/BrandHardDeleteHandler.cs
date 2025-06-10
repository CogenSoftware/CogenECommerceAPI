using Core.Application.Bases;
using Core.Application.Features.Brand.Rules;
using Core.Application.Interfaces.AutoMapper;
using Core.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Features.Brand.Commands.HardDelete;

public class BrandHardDeleteHandler : BaseHandler, IRequestHandler<BrandHardDeleteRequest, Unit>
{
    private readonly BrandRules _brandRules;
    public BrandHardDeleteHandler(
        BrandRules brandRules,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) :
        base(mapper, unitOfWork, httpContextAccessor)
    {
        _brandRules = brandRules;
    }

    public async Task<Unit> Handle(BrandHardDeleteRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Brand? brand = await _unitOfWork.GetReadRepository<Domain.Entities.Brand>().GetAsync(x => x.Id == request.Id);
        await _brandRules.BrandNotFoundRule(brand);
        await _unitOfWork.GetWriteRepository<Domain.Entities.Brand>().HardRemoveAsync(brand!);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}