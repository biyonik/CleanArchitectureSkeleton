using System.Reflection;

namespace CleanArchitectureSkeleton.Persistence;

public static class PersistenceAssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}