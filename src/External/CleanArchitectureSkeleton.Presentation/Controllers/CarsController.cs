using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Queries;
using CleanArchitectureSkeleton.Domain.Entities;
using CleanArchitectureSkeleton.Presentation.Controllers.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSkeleton.Presentation.Controllers;

public sealed class CarsController: BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(Create.Command command, CancellationToken cancellationToken)
    {
        IResult mediatr = await Mediator.Send(command, cancellationToken);
        return HandleResult(mediatr);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAll.Query query, CancellationToken cancellationToken)
    {
        IDataResult<List<Car>> mediatr = await Mediator.Send(query, cancellationToken);
        return HandleResult(mediatr);
    }
}