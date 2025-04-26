using Microsoft.AspNetCore.Mvc;

namespace CustomBinderDemo.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] decimal? test)
    {
        return Ok(new { Message = $"Hello from TestController! You gave me the value of {test}." });
    }
}
