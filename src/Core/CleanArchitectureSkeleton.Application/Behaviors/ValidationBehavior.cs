﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanArchitectureSkeleton.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
    where TRequest: class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();
        
        var context = new ValidationContext<TRequest>(request);
        var errorDictionary = _validators
            .Select(s => s.Validate(context))
            .SelectMany(s => s.Errors)
            .Where(s => s != null)
            .GroupBy(
                s => s.PropertyName,
                s => s.ErrorMessage,
                (key, errors) => new { PropertyName = key, Errors = errors.Distinct().ToArray() }
                
            ).ToDictionary(s => s.PropertyName, s => s.Errors[0]);

        if (errorDictionary.Any())
        {
            var errors = errorDictionary.Select(s => new ValidationFailure
            {
                PropertyName = s.Key,
                ErrorMessage = s.Value
            });
            throw new ValidationException(errors);
        }

        return await next();
    }
}