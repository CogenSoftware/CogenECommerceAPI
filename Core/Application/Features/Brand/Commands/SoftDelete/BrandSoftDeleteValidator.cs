using FluentValidation;

namespace Core.Application.Features.Brand.Commands.SoftDelete;

public class BrandSoftDeleteValidator : AbstractValidator<BrandSoftDeleteRequest>
{
    public BrandSoftDeleteValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0!");
    }
}