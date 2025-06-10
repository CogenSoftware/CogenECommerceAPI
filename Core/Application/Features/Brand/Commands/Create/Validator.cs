using FluentValidation;

namespace Core.Application.Features.Brand.Commands.Create;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(1).WithMessage("Name field must be at least 1 character!")
            .MaximumLength(100).WithMessage("Name field must be maximum 100 characters!");
    }
}