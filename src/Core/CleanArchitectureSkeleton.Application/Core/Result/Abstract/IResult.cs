namespace CleanArchitectureSkeleton.Application.Core.Result.Abstract;

public interface IResult
{
    public string Message { get; set; }
    public bool IsSucceed { get; set; }
}