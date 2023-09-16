using CleanArchitectureSkeleton.Application.Core.Result.Abstract;

namespace CleanArchitectureSkeleton.Application.Core.Result.Concrete;

public class ErrorDataResult<T>: IDataResult<T>
{
    public string Message { get; set; }
    public bool IsSucceed { get; set; }
    public T Data { get; set; }

    public ErrorDataResult(T data)
    {
        IsSucceed = false;
        Data = data;
    }

    public ErrorDataResult(T data, string message): this(data)
    {
        Message = message;
        Data = data;
        IsSucceed = false;
    }

    public ErrorDataResult(string message): this(default, message)
    {
        IsSucceed = false;
    }
}