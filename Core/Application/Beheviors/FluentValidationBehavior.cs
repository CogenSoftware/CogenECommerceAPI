using FluentValidation;
using MediatR;

namespace Core.Application.Beheviors
{
    public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public FluentValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var result = _validator.Validate(context);
            var failures = result.Errors
                .Where(x => x != null)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}