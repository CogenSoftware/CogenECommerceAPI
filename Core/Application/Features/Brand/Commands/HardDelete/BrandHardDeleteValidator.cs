using FluentValidation;

namespace Core.Application.Features.Brand.Commands.HardDelete;

public class BrandHardDeleteValidator : AbstractValidator<BrandHardDeleteRequest>
{
    public BrandHardDeleteValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0!");
    }
}