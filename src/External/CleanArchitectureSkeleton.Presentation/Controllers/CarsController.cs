using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Presentation.Controllers.Abstraction;
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
}