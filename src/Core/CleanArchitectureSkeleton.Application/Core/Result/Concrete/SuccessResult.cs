using CleanArchitectureSkeleton.Application.Core.Result.Abstract;

namespace CleanArchitectureSkeleton.Application.Core.Result.Concrete;

public class SuccessResult: IResult
{
    public string Message { get; set; }
    public bool IsSucceed { get; set; }

    public SuccessResult()
    {
        IsSucceed = true;
    }
    
    public SuccessResult(string message)
    {
        Message = message;
        IsSucceed = true;
    }
}