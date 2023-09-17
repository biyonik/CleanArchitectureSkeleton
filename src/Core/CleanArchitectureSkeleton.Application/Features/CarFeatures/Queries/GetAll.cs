using CleanArchitectureSkeleton.Application.Constants.Messages;
using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Core.Result.Concrete;
using CleanArchitectureSkeleton.Application.Messaging;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Domain.Entities;
using MediatR;

namespace CleanArchitectureSkeleton.Application.Features.CarFeatures.Queries;

public sealed class GetAll
{
    public sealed record Query() : IQuery<IDataResult<IEnumerable<Car>>>;
    
    public sealed class Handler : IRequestHandler<Query, IDataResult<IEnumerable<Car>>>
    {
        private readonly ICarService _carService;

        public Handler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IDataResult<IEnumerable<Car>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _carService.GetAll(cancellationToken);
            if (result.Any())
            {
                return new SuccessDataResult<IEnumerable<Car>>(result, CarMessageConstants.GetAllSuccess);
            }
            return new ErrorDataResult<IEnumerable<Car>>(null, CarMessageConstants.GetAllError);
        }
    }
}