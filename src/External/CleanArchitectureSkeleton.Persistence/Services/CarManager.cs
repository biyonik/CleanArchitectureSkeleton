using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Domain.Entities;
using CleanArchitectureSkeleton.Persistence.Contexts;

namespace CleanArchitectureSkeleton.Persistence.Services;

public class CarManager: ICarService
{
    private readonly AppDbContext _context;

    public CarManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Create.Command carCommand, CancellationToken cancellationToken = default)
    {
        Car car = new Car()
        {
            Name = carCommand.AddForCarDto.Name,
            Model = carCommand.AddForCarDto.Model,
            HorsePower = carCommand.AddForCarDto.HorsePower
        };
        await _context.Set<Car>().AddAsync(car, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}