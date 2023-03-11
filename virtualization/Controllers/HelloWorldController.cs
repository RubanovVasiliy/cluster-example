using Microsoft.AspNetCore.Mvc;

namespace virtualization.Controllers;

[ApiController]
[Route("hello")]
public class HelloWorldController : ControllerBase
{
    
    [HttpGet]
    public string Get()
    {
        return "Hello world!";
    }
}