using CleanArchitectureSkeleton.Domain.Entities;
using CleanArchitectureSkeleton.Domain.Repositories;
using CleanArchitectureSkeleton.Persistence.Contexts;
using GenericRepository;

namespace CleanArchitectureSkeleton.Persistence.Repositories;

public sealed class CarRepository: Repository<Car, AppDbContext>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
}