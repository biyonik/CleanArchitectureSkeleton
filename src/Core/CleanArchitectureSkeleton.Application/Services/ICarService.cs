using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Queries;
using CleanArchitectureSkeleton.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitectureSkeleton.Application.Services;

public interface ICarService
{
    Task AddAsync(Create.Command carCommand, CancellationToken cancellationToken = default);
    Task<PaginationResult<Car>> GetAll(GetAll.Query request, CancellationToken cancellationToken = default);
}