using CleanArchitectureSkeleton.Application.Constants.Messages;
using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Core.Result.Concrete;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.DTOs;
using CleanArchitectureSkeleton.Application.Messaging;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Application.Validators;
using FluentValidation;

namespace CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;

public sealed class Create
{
    public sealed record Command(AddForCarDto AddForCarDto) : ICommand<IResult>;

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.AddForCarDto).SetValidator(new CarValidator());
        }
    }

    public sealed class Handler : ICommandHandler<Command, IResult>
    {
        private readonly ICarService _carService;

        public Handler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IResult> Handle(Command request, CancellationToken cancellationToken)
        {
            var validator = new CommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                return new ErrorDataResult<List<string>>(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            var result = await _carService.AddAsync(request, cancellationToken);
            return !result 
                ? new ErrorResult(CarMessageConstants.AddError)
                : new SuccessResult(CarMessageConstants.AddSuccess);
        }
    }
}