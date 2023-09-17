using CleanArchitectureSkeleton.Application.Core.Result.Abstract;
using CleanArchitectureSkeleton.Application.Core.Result.Concrete;
using CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;
using CleanArchitectureSkeleton.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitectureSkeleton.UnitTest;

public class CarsControllerUnitTest
{
    [Fact]
    public async Task CreateCar_ReturnsOkResult_WhenRequestIsValid()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        Create.Command command = new("Toyoya", "Corolla", 100);
        CancellationToken cancellationToken = new();
        
        mediatorMock.Setup(m => m.Send(command, cancellationToken))
            .ReturnsAsync(new SuccessResult());
        
        var controller = new CarsController();
        controller.Mediator = mediatorMock.Object;
        
        // Act
        var result = await controller.Create(command, cancellationToken);
        // Assert
        Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<SuccessResult>(((OkObjectResult) result).Value);
    }
}