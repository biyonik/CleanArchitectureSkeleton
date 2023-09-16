using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Core.Result.Concrete;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.DTOs;
using CleanArchitectureSkeleton.Application.Validators;
using FluentValidation;
using MediatR;

namespace CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;

public sealed class Create
{
    public sealed record Command(AddForCarDto AddForCarDto) : IRequest<IResult<Unit>>;

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.AddForCarDto).SetValidator(new CarValidator());
        }
    }

    public sealed class Handler : IRequestHandler<Command, IResult<Unit>>
    {
        public async Task<IResult<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Result<Unit>().Success(Unit.Value));
        }
    }
}