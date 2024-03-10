using Zoo.Common.Helper;
using Zoo.Common.Models;

namespace Zoo.Management.UnitTests
{
    public class ParseHelperUnitTests
    {
        private ParseHelper _parseHelper;
        [SetUp]
        public void Setup()
        {
            _parseHelper = new ParseHelper();
        }

        [Test]
        public void ParseCsvLine_ValidLine_ReturnsSpeciesObject()
        {
            // Arrange
            string line = "Lion,0.10,meat";

            // Act
            var result = _parseHelper.ParseCsvLine(line);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Lion"));
            Assert.That(result.FoodRate, Is.EqualTo(0.10m));
            Assert.That(result.Type, Is.EqualTo(AnimalType.Carnivore));
            Assert.That(result.MeatPercentage, Is.EqualTo(0m));
        }

        [Test]
        public void ParseCsvLine_ValidOmnivoreLine_ReturnsSpeciesObjectWithMeatPercentage()
        {
            // Arrange
            string line = "Wolf,0.07,both,90%";

            // Act
            var result = _parseHelper.ParseCsvLine(line);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Wolf"));
            Assert.That(result.FoodRate, Is.EqualTo(0.07m));
            Assert.That(result.Type, Is.EqualTo(AnimalType.Omnivore));
            Assert.That(result.MeatPercentage, Is.EqualTo(0.9m));
        }

        [Test]
        public void ParseTxtLine_ValidLine_ReturnsFoodAndRate()
        {
            // Arrange
            string line = "Meat=12.56";
            string expectedFood = "meat";
            decimal expectedRate = 12.56m;

            // Act
            _parseHelper.ParseTxtLine(line, out string food, out decimal rate);

            // Assert
            Assert.That(food, Is.EqualTo(expectedFood));
            Assert.That(rate, Is.EqualTo(expectedRate));
        }
    }
}