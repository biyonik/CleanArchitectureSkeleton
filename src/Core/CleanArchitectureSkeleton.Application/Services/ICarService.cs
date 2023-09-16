using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;

namespace CleanArchitectureSkeleton.Application.Services;

public interface ICarService
{
    Task<bool> AddAsync(Create.Command carCommand, CancellationToken cancellationToken = default);
}