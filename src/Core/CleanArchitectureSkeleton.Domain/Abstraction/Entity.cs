namespace CleanArchitectureSkeleton.Domain.Abstraction;

public abstract class Entity
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}