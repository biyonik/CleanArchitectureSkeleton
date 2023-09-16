using AutoMapper;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Domain.Entities;
using CleanArchitectureSkeleton.Persistence.Contexts;

namespace CleanArchitectureSkeleton.Persistence.Services;

public class CarManager: ICarService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CarManager(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> AddAsync(Create.Command carCommand, CancellationToken cancellationToken = default)
    {
        Car car = _mapper.Map<Car>(carCommand.AddForCarDto);
        await _context.Set<Car>().AddAsync(car, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}