using AutoMapper;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.DTOs;
using CleanArchitectureSkeleton.Domain.Entities;

namespace CleanArchitectureSkeleton.Persistence.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<AddForCarDto, Car>().ReverseMap();
    }
}