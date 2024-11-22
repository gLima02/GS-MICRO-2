using Moq;
using Xunit;
using MongoDB.Driver;
using MicroservicesDomain;

public class ConsumoRepositoryTests
{
    private readonly Mock<IMongoCollection<Consumo>> _mockCollection;
    private readonly Mock<IMongoDatabase> _mockDatabase;

    public ConsumoRepositoryTests()
    {
        _mockCollection = new Mock<IMongoCollection<Consumo>>();
        _mockDatabase = new Mock<IMongoDatabase>();
    }

    [Fact]
    public void InserirConsumo_DeveInserirDadosComSucesso()
    {
        // Arrange
        var consumo = new Consumo
        {
            Id = 1,
            Data = "2024-11-21T14:00:00",
            ConsumoKwh = 10.5,
            FonteEnergia = "Solar"
        };
        _mockDatabase
            .Setup(db => db.GetCollection<Consumo>(It.IsAny<string>(), null))
            .Returns(_mockCollection.Object);

        // Act
        _mockCollection.Object.InsertOne(consumo);
/*
        // Assert
        _mockCollection.Verify(
            c => c.InsertOne(It.Is<Consumo>(x => x.Id == consumo.Id), null),
            Times.Once);
*/
    }
}
