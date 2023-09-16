namespace CleanArchitectureSkeleton.Application.Core.Result.Abstract;

public interface IResult<T>
{
    public bool IsSuccess { get; set; }
    public T Value { get; set; }
    public string ErrorMessage { get; set; }

    IResult<T> Success(T value);
    IResult<T> Failure(string errorMessage);
}