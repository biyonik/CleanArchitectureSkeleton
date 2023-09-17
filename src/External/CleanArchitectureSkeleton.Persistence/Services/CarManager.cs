using AutoMapper;
using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Domain.Entities;
using CleanArchitectureSkeleton.Domain.Repositories;
using GenericRepository;

namespace CleanArchitectureSkeleton.Persistence.Services;

public class CarManager: ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarManager(IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(Create.Command carCommand, CancellationToken cancellationToken = default)
    {
        Car car = _mapper.Map<Car>(carCommand);
        await _carRepository.AddAsync(car, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IQueryable<Car>> GetAll(CancellationToken cancellationToken = default)
    {
        return _carRepository.GetAll();
    }
}