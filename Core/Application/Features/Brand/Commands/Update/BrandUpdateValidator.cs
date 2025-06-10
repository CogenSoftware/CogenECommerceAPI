using FluentValidation;

namespace Core.Application.Features.Brand.Commands.Update;

public class BrandUpdateValidator : AbstractValidator<BrandUpdateRequest>
{
    public BrandUpdateValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0!");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(1).WithMessage("Name field must be at least 1 character!")
            .MaximumLength(100).WithMessage("Name field must be maximum 100 characters!");
    }
}