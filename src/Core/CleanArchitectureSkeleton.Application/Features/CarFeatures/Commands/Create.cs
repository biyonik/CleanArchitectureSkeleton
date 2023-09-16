using CleanArchitectureSkeleton.Application.Constants.Messages;
using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Core.Result.Concrete;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.DTOs;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Application.Validators;
using FluentValidation;
using MediatR;

namespace CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;

public sealed class Create
{
    public sealed record Command(AddForCarDto AddForCarDto) : IRequest<IResult<string>>;

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.AddForCarDto).SetValidator(new CarValidator());
        }
    }

    public sealed class Handler : IRequestHandler<Command, IResult<string>>
    {
        private readonly ICarService _carService;

        public Handler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IResult<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await _carService.AddAsync(request, cancellationToken);
            return !result 
                ? new Result<string>().Failure(CarMessageConstants.AddError)
                : new Result<string>().Success(CarMessageConstants.AddSuccess);
        }
    }
}