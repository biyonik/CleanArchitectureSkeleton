using CleanArchitectureSkeleton.Application.Constants.Messages;
using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Core.Result.Concrete;
using CleanArchitectureSkeleton.Application.Messaging;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitectureSkeleton.Application.Features.CarFeatures.Queries;

public sealed class GetAll
{
    public sealed record Query(
        int PageNumber = 1,
        int PageSize = 10,
        string? search = null
    ) : IQuery<IDataResult<List<Car>>>;
    
    public sealed class Handler : IRequestHandler<Query, IDataResult<List<Car>>>
    {
        private readonly ICarService _carService;

        public Handler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IDataResult<List<Car>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _carService.GetAll(request, cancellationToken);
            if (result.Datas.Any())
            {
                return new SuccessPaginationResult<List<Car>>(
                    data: result.Datas.ToList(),
                    pageNumber: result.PageNumber,
                    pageSize: result.PageSize,
                    totalPage: result.TotalPages,
                    isFirstPage: result.IsFirstPage,
                    isLastPage: result.IsLastPage,
                    message: CarMessageConstants.GetAllSuccess
                );
            }
            return new ErrorDataResult<List<Car>>(null, CarMessageConstants.GetAllError);
        }
    }
}