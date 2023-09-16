using FluentValidation;

namespace CleanArchitectureSkeleton.WebAPI.Middlewares;

public sealed class ExceptionMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
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
}
