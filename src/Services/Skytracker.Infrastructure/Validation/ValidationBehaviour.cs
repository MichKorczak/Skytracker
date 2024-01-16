using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Skytracker.Infrastructure.Validation;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            return await next();
        }

        var errors = _validators
            .Select(v => v.Validate(request))
            .Where(v => v.IsValid).ToArray();

        if (!errors.Any())
        {
            return await next();
        }

        return PrepareErrors(errors);
    }

    private TResponse PrepareErrors(IEnumerable<ValidationResult> validationResults)
    {
        var errors = validationResults.SelectMany(v => v.Errors).ToArray();

        var validationErrors = errors.Select(e => Error.Validation(e.PropertyName, e.ErrorMessage)).ToList();

        try
        {
            return (TResponse)(dynamic) validationErrors;
        }
        catch
        {
            throw new ValidationException(errors);
        }
    }
}
