using Core.Application.Bases;
using Core.Application.Features.Brand.Exceptions;

namespace Core.Application.Features.Brand.Rules;

public class BrandRules : BaseRules
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("", "S2325")]
    public Task BrandNameMustBeUniqueRule(IList<Domain.Entities.Brand> brands, string name)
    {
        if (brands.Any(x => x.Name == name))
            throw new BrandNameMustBeUniqueException();

        return Task.CompletedTask;
    }
}