using Newtonsoft.Json;

namespace CleanArchitectureSkeleton.WebAPI.Middlewares;

public sealed class ErrorResult: ErrorStatusCode
{
    public string Message { get; set; }
}

public sealed class ValidationErrorDetails: ErrorStatusCode
{
    public IDictionary<string, string[]> Errors { get; set; }
}

public class ErrorStatusCode
{
    public int StatusCode { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}