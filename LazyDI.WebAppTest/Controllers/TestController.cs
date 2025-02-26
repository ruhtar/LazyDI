using LazyDI.WebAppTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace LazyDI.WebAppTest.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ITestSingletonService testSingletonService;
    private readonly ITestTransientService testTransientService;
    public TestController(ITestSingletonService testSingletonService, ITestTransientService testTransientService)
    {
        this.testSingletonService = testSingletonService;
        this.testTransientService = testTransientService;
    }

    [HttpGet("singleton")]
    public IActionResult TestSingleton()
    {
        return Ok(testSingletonService.GetNumber());
    }

    [HttpGet("transient")]
    public IActionResult TestTransient()
    {
        return Ok(testTransientService.GetNumber());
    }
}
