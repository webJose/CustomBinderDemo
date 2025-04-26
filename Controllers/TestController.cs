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

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { Message = $"You requested item with ID: {id}" });
    }

    [HttpPost]
    public IActionResult Post([FromBody] object value)
    {
        return Created("", new { Message = "Item created successfully", Value = value });
    }
}
