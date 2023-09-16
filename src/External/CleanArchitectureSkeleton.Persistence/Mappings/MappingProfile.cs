using AutoMapper;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Domain.Entities;

namespace CleanArchitectureSkeleton.Persistence.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Create.Command, Car>().ReverseMap();
    }
}