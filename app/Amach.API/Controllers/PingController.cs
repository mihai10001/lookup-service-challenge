using Microsoft.AspNetCore.Mvc;

namespace Amach.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : Controller
{
    [HttpGet]
    public string Get()
    {
        return "pong";
    }
}
