namespace CleanArchitectureSkeleton.Application.Core.Result.Abstract;

public interface IDataResult<T>: IResult
{
    public T Data { get; set; }
}