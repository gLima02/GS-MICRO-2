using Microsoft.AspNetCore.Mvc;

namespace MicroservicesEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealthStatus()
        {
            var healthStatus = new
            {
                status = "ok",
                message = "O serviço de monitoramento de consumo de energia elétrica está funcionando corretamente.",
            };

            return Ok(healthStatus);
        }

    }
}