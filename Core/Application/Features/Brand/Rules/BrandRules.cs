using Core.Application.Bases;
using Core.Application.Features.Brand.Exceptions;

namespace Core.Application.Features.Brand.Rules;

public class BrandRules : BaseRules
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("", "S2325")]
    public Task BrandNameMustBeUniqueRule(IList<Domain.Entities.Brand> brands, string name, int? Id = null)
    {
        if (brands.Any(x => x.Name == name && (Id is null || x.Id != Id)))
            throw new BrandNameMustBeUniqueException();

        return Task.CompletedTask;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("", "S2325")]
    public Task BrandNotFoundRule(Domain.Entities.Brand? brand)
    {
        if (brand is null)
            throw new BrandNotFoundException();

        return Task.CompletedTask;
    }
}