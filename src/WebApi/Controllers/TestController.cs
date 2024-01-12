using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("TestController => {Get}", nameof(Get));
        return Ok("Hello World!");
    }
    
    [HttpPost]
    public IActionResult Post()
    {
        _logger.LogInformation("TestController => {Post}", nameof(Get));
        return Ok("Hello World!");
    }
}