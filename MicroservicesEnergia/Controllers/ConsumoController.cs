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
            try
            {
                // Log para depurar o consumo recebido
                Console.WriteLine($"Recebido: {JsonConvert.SerializeObject(consumo)}");

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repository.SalvarConsumo(consumo);

                return Ok(new { mensagem = "Criado com sucesso!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return StatusCode(500, new { mensagem = "Erro interno do servidor." });
            }
        }
    }
}
