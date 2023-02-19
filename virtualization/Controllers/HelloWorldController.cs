using Microsoft.AspNetCore.Mvc;

namespace virtualization.Controllers;

[ApiController]
[Route("")]
public class HelloWorldController : ControllerBase
{
    
    [HttpGet]
    public string Get()
    {
        return "Hello world!";
    }
}