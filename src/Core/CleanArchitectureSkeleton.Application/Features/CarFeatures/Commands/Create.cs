using CleanArchitectureSkeleton.Application.Constants.Messages;
using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Core.Result.Concrete;
using CleanArchitectureSkeleton.Application.Messaging;
using CleanArchitectureSkeleton.Application.Services;

namespace CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;

public sealed class Create
{
    public sealed record Command(
        string Name,
        string Model,
        int HorsePower
    ) : ICommand<IResult>;
    

    public sealed class Handler : ICommandHandler<Command, IResult>
    {
        private readonly ICarService _carService;

        public Handler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IResult> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await _carService.AddAsync(request, cancellationToken);
            return !result 
                ? new ErrorResult(CarMessageConstants.AddError)
                : new SuccessResult(CarMessageConstants.AddSuccess);
        }
    }
}