namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
public class BaseController : ControllerBase
{
}
