using CleanArchitectureSkeleton.Application.Core.Result.Abstract;

namespace CleanArchitectureSkeleton.Application.Core.Result.Concrete;

public class Result<T>: IResult<T>
{
    public bool IsSuccess { get; set; }
    public T Value { get; set; }
    public string ErrorMessage { get; set; }

    public IResult<T> Success(T value) => new Result<T>
    {
        IsSuccess = true,
        Value = value
    };

    public IResult<T> Failure(string errorMessage) => new Result<T>
    {
        IsSuccess = false,
        ErrorMessage = errorMessage
    };
}