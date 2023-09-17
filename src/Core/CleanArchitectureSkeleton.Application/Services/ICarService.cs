using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Domain.Entities;

namespace CleanArchitectureSkeleton.Application.Services;

public interface ICarService
{
    Task AddAsync(Create.Command carCommand, CancellationToken cancellationToken = default);
    Task<IQueryable<Car>> GetAll(CancellationToken cancellationToken = default);
}