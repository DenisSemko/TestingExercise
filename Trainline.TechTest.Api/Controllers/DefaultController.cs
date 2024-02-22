namespace Trainline.TechTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DefaultController : ControllerBase
{
    private readonly ILogger<DefaultController> _logger;

    public DefaultController(ILogger<DefaultController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IActionResult Get()
    {
       // Do something
       throw new NotImplementedException();
    }
}