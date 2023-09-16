namespace CleanArchitectureSkeleton.WebAPI.Middlewares;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionMiddleware>();
        
        return builder;
    }
}