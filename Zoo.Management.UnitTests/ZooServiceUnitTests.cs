
using Microsoft.Extensions.Logging;
using Moq;
using Zoo.Common;
using Zoo.Common.CustomExceptions;
using Zoo.Common.Helper;
using Zoo.Common.Models;
using Zoo.Core.Implementations;

namespace Zoo.Management.UnitTests
{
    public class ZooServiceUnitTests
    {
        private ZooService _zooService;
        private Mock<IDataHelper> _dataHelperMock;
        private Mock<ILogger<ZooService>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _dataHelperMock = new Mock<IDataHelper>();
            _loggerMock = new Mock<ILogger<ZooService>>();
            _zooService = new ZooService(_dataHelperMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task CalculateCostAsync_ValidInput_CorrectCalculation()
        {
            // Arrange
            var zooAnimals = new List<Animal> {
                new Animal { Name = "Lion", Weight = 160, Species = new Species { Name = "Simba", Type = AnimalType.Carnivore, FoodRate = 0.10M } },
                new Animal { Name = "Giraffe", Weight = 200, Species = new Species { Name = "Hanna", Type = AnimalType.Herbivore, FoodRate = 0.08M } },
                new Animal { Name = "Wolf", Weight = 78, Species = new Species { Name = "Pin", Type = AnimalType.Omnivore, FoodRate = 0.07M, MeatPercentage = 0.9M } },
            };
            var prices = new Dictionary<string, decimal> { { Constants.Meat, 12.56M }, { Constants.Fruit, 5.60M } };
            var numDays = 1;

            _dataHelperMock.Setup(dh => dh.LoadZooAnimalsAsync()).ReturnsAsync(zooAnimals);
            _dataHelperMock.Setup(dh => dh.LoadPricesAsync()).ReturnsAsync(prices);

            // Act
            var result = await _zooService.CalculateCostAsync(numDays);

            // Assert
            Assert.That(result.Cost, Is.EqualTo(355.33744M));
        }

        [Test]
        public async Task CalculateCostAsync_InValidInput_UnsupportedAnimalType_ThrowsError()
        {
            // Arrange
            var zooAnimals = new List<Animal> {
                new Animal { Name = "Lion", Weight = 150, Species = new Species { Name = "Lion", Type = (AnimalType)10, FoodRate = 2.5M } },
            };
            var prices = new Dictionary<string, decimal> { { Constants.Meat, 10 }, { Constants.Fruit, 5 } };
            var numDays = 5;

            _dataHelperMock.Setup(dh => dh.LoadZooAnimalsAsync()).ReturnsAsync(zooAnimals);
            _dataHelperMock.Setup(dh => dh.LoadPricesAsync()).ReturnsAsync(prices);

            // Act & Assert
            Assert.ThrowsAsync<DataLoadException>(() => _zooService.CalculateCostAsync(numDays));
        }

        [Test]
        public async Task CalculateCostAsync_DataLoadExceptionThrown_ErrorLoggedAndRethrown()
        {
            // Arrange
            _dataHelperMock.Setup(dh => dh.LoadZooAnimalsAsync()).ThrowsAsync(new DataLoadException("Test"));
            var numDays = 5;

            // Act & Assert
            Assert.ThrowsAsync<DataLoadException>(() => _zooService.CalculateCostAsync(numDays));

        }

        [Test]
        public async Task CalculateCostAsync_UnexpectedExceptionThrown_ErrorLoggedAndRethrown()
        {
            // Arrange
            _dataHelperMock.Setup(dh => dh.LoadZooAnimalsAsync()).ThrowsAsync(new System.Exception("Test"));
            var numDays = 5;

            // Act & Assert
            Assert.ThrowsAsync<System.Exception>(() => _zooService.CalculateCostAsync(numDays));
            
        }

    }
}
