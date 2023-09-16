using System.Reflection;

namespace CleanArchitectureSkeleton.Application;

public static class ApplicationAssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}