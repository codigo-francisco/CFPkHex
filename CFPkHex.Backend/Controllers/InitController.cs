using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CFPkHex.Backend.Controllers
{
    [ApiController]
    [Route("/api/init")]
    public class InitController : ControllerBase
    {
        [HttpGet]
        public IActionResult InitApp()
        {
            return Ok(new { Estado = "App Inicializada" });
        }
    }
}
