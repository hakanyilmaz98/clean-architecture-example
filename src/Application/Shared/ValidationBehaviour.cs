using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Shared;
public sealed class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, IResult>
    where TRequest : IRequest<IResult>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<IResult> Handle(TRequest request, RequestHandlerDelegate<IResult> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var validator = _validators.First();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid) return await next();

        return TypedResults.ValidationProblem(validationResult.ToDictionary());
    }
}
