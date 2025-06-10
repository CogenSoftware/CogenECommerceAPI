using FluentValidation;

namespace Core.Application.Features.Brand.Commands.Create;

public class BrandCreateValidator : AbstractValidator<BrandCreateRequest>
{
    public BrandCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(1).WithMessage("Name field must be at least 1 character!")
            .MaximumLength(100).WithMessage("Name field must be maximum 100 characters!");
    }
}