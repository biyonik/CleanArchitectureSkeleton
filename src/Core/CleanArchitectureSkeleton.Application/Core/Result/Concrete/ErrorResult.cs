using CleanArchitectureSkeleton.Application.Core.Result.Abstract;

namespace CleanArchitectureSkeleton.Application.Core.Result.Concrete;

public class ErrorResult: IResult
{
    public string Message { get; set; }
    public bool IsSucceed { get; set; }

    public ErrorResult()
    {
        IsSucceed = false;
    }

    public ErrorResult(string message)
    {
        Message = message;
        IsSucceed = false;
    }
}