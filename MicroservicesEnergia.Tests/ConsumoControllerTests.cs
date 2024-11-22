using MicroservicesDomain;
using MicroservicesEnergia.Controllers;
using MicroservicesRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MicroservicesEnergia
{
    public class ConsumoControllerTests
    {
        private readonly Mock<IConsumoRepository> _mockRepository;
        private readonly ConsumoController _controller;

        public ConsumoControllerTests()
        {
            _mockRepository = new Mock<IConsumoRepository>();
            _controller = new ConsumoController(_mockRepository.Object);
        }

        // Cenário 1: Sucesso na Inserção de Consumo
        [Fact]
        public async Task PostConsumo_ReturnsOk_WhenConsumoIsValid()
        {
            var consumo = new Consumo
            {
                Id = 1,
                Data = "2024-11-22",
                ConsumoKwh = 150.0,
                Custo = 50.0,
                FonteEnergia = "Solar",
                EmissaoCO2 = 20.0,
                Localizacao = "Local A",
                Dispositivo = "Dispositivo A",
                PercentualEnergiaRenovavel = 75.0,
                PicoConsumo = false,
                UsuarioResponsavel = "Usuario 1"
            };

            _mockRepository.Setup(repo => repo.SalvarConsumo(It.IsAny<Consumo>())).Returns(Task.CompletedTask);

            var result = await _controller.PostConsumo(consumo);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        // Cenário 2: Falha ao Inserir Consumo (Bad Request)
        [Fact]
        public async Task PostConsumo_ReturnsBadRequest_WhenConsumoIsInvalid()
        {
            var consumo = new Consumo
            {
                Id = 0,  // ID inválido (zero)
                Data = null, // Dados faltando
                ConsumoKwh = 0.0,  // Consumo inválido
            };

            _controller.ModelState.AddModelError("Data", "Campo obrigatório");

            var result = await _controller.PostConsumo(consumo);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        // Cenário 3: Sucesso ao Recuperar Todos os Consumos
        [Fact]
        public async Task GetConsumo_ReturnsOk_WhenConsumosExist()
        {
            var consumos = new List<Consumo>
            {
                new Consumo { Id = 1, Data = "2024-11-22", ConsumoKwh = 150.0, Custo = 50.0 },
                new Consumo { Id = 2, Data = "2024-11-23", ConsumoKwh = 100.0, Custo = 40.0 }
            };

            _mockRepository.Setup(repo => repo.ListarConsumos()).ReturnsAsync(consumos);

            var result = await _controller.GetConsumo();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<List<Consumo>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        // Cenário 4: Não Encontrar Consumos (Not Found)
        [Fact]
        public async Task GetConsumo_ReturnsNotFound_WhenNoConsumosExist()
        {
            _mockRepository.Setup(repo => repo.ListarConsumos()).ReturnsAsync((List<Consumo>)null);

            var result = await _controller.GetConsumo();

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        // Cenário 5: Erro Interno no Servidor (Status Code 500)
        [Fact]
        public async Task PostConsumo_ReturnsStatus500_WhenExceptionOccurs()
        {
            var consumo = new Consumo
            {
                Id = 1,
                Data = "2024-11-22",
                ConsumoKwh = 150.0,
                Custo = 50.0
            };

            _mockRepository.Setup(repo => repo.SalvarConsumo(It.IsAny<Consumo>())).ThrowsAsync(new Exception("Erro inesperado"));

            var result = await _controller.PostConsumo(consumo);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var errorMessage = Assert.IsType<dynamic>(statusCodeResult.Value);
            Assert.Equal("Erro interno do servidor.", errorMessage.mensagem.ToString());
        }
    }
}
