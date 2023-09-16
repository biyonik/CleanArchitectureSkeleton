using CleanArchitectureSkeleton.Application.Core.Result.Abstract;

namespace CleanArchitectureSkeleton.Application.Core.Result.Concrete;

public class SuccessDataResult<T>: IDataResult<T>
{
    public string Message { get; set; }
    public bool IsSucceed { get; set; }
    public T Data { get; set; }

    public SuccessDataResult(T data)
    {
        IsSucceed = true;
        Data = data;
    }

    public SuccessDataResult(T data, string message): this(data)
    {
        Message = message;
        Data = data;
        IsSucceed = true;
    }

    public SuccessDataResult(string message): this(default, message)
    {
        IsSucceed = true;
    }
}