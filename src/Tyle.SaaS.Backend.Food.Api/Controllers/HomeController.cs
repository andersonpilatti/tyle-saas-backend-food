using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Tyle.Packages.Bases.Controllers;

namespace Tyle.SaaS.Backend.Food.Api.Controllers;

[ApiController]
[Route("api/home")]
public sealed class HomeController : BaseController
{
    public HomeController() : base("Tyle Food API")
    {
        version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown";
    }

    [HttpGet("status")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public IActionResult GetStatus() => Ok(new { Service = "Tyle Food API", Status = "Ready" });
}
