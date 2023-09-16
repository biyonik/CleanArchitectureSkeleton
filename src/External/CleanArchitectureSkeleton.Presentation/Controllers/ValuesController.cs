using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSkeleton.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Values")]
[Produces("application/json")]
[Consumes("application/json")]
public sealed class ValuesController: ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get() => new string[] { "value1", "value2" };
}