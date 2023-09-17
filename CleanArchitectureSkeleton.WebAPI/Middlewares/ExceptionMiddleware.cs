using CleanArchitectureSkeleton.Domain.Entities;
using CleanArchitectureSkeleton.Persistence.Contexts;
using FluentValidation;

namespace CleanArchitectureSkeleton.WebAPI.Middlewares;

public sealed class ExceptionMiddleware: IMiddleware
{
    private readonly AppDbContext _context;

    public ExceptionMiddleware(AppDbContext context)
    {
        _context = context;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await LogExceptionToDatabaseAsync(ex, context.Request);
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        if (ex.GetType() == typeof(ValidationException))
        {
            context.Response.StatusCode = 403;
            var validationException = (ValidationException) ex;
            var errorsDictionary = validationException.Errors.ToDictionary(error => error.PropertyName, error => new[] { error.ErrorMessage });

            var errorDetails = new ValidationErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Errors = errorsDictionary
            }.ToString();
            
                
            return context.Response.WriteAsync(errorDetails);
        }
        return context.Response.WriteAsync(new ErrorResult
        {
            Message = ex.Message,
            StatusCode = context.Response.StatusCode
        }.ToString());
    }

    private async Task LogExceptionToDatabaseAsync(Exception ex, HttpRequest httpRequest)
    {
        ErrorLog errorLog = new()
        {
            ErrorMessage = ex.Message,
            StackTrace = ex.StackTrace,
            RequestPath = httpRequest.Path.ToString(),
            RequestMethod = httpRequest.Method,
            Timestamp = DateTime.Now
        };
        
        await _context.Set<ErrorLog>().AddAsync(errorLog, default);
        await _context.SaveChangesAsync(default);
    }
}
