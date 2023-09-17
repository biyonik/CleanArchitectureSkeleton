using AutoMapper;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Queries;
using CleanArchitectureSkeleton.Application.Services;
using CleanArchitectureSkeleton.Domain.Entities;
using CleanArchitectureSkeleton.Domain.Repositories;
using EntityFrameworkCorePagination.Nuget.Pagination;
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
    
    public async Task<PaginationResult<Car>> GetAll(GetAll.Query request,CancellationToken cancellationToken = default)
    {
        return await _carRepository
            .GetWhere(x => x.Name.Contains(request.search ?? string.Empty))
            .OrderBy(x => x.Name)
            .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}