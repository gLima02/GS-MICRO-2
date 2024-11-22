using MicroservicesDomain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using MicroservicesRepository.Interfaces;

namespace MicroservicesEnergia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private readonly IConsumoRepository _repository;

        public ConsumoController(IConsumoRepository repository)
        {
            _repository = repository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetConsumo()
        {


            var consumos = await _repository.ListarConsumos();

            if (consumos == null)
            {
                return NotFound();
            }

            string consumosJson = JsonConvert.SerializeObject(consumos);

            return Ok(consumos);
        }

        [HttpPost]
        public async Task<IActionResult> PostConsumo([FromBody] Consumo consumo)
        {
            await _repository.SalvarConsumo(consumo);


            return Ok(new { mensagem = "Criado com sucesso!" });

        }
    }
}
