﻿using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.DTOs;
using CleanArchitectureSkeleton.Presentation.Controllers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSkeleton.Presentation.Controllers;

public sealed class CarsController: BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(AddForCarDto addForCarDto, CancellationToken cancellationToken)
    {
        Create.Command command = new Create.Command(addForCarDto);
        var mediatr = await Mediator.Send(command, cancellationToken);
        return HandleResult(mediatr);
    }
}