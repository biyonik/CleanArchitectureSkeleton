using CleanArchitectureSkeleton.Domain.Abstraction;

namespace CleanArchitectureSkeleton.Domain.Entities;

public sealed class Car: Entity
{
    public string Name { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
}