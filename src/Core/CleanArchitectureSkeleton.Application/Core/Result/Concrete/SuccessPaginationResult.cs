using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitectureSkeleton.Application.Core.Result.Concrete;

public class SuccessPaginationResult<T> : IDataResult<T>
{
    public string Message { get; set; }
    public bool IsSucceed { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPage { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
    public T Data { get; set; }

    public SuccessPaginationResult(T data, int pageNumber, int pageSize, int totalPage, bool isFirstPage,
        bool isLastPage)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPage = totalPage;
        IsFirstPage = isFirstPage;
        IsLastPage = isLastPage;
        IsSucceed = true;
    }

    public SuccessPaginationResult(T data, int pageNumber, int pageSize, int totalPage, bool isFirstPage,
        bool isLastPage, string message) : this(data, pageNumber, pageSize, totalPage, isFirstPage, isLastPage)
    {
        Message = message;
        IsSucceed = true;
    }
}