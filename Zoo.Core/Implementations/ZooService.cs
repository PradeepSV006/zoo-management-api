using Microsoft.Extensions.Logging;
using Zoo.Common;
using Zoo.Common.CustomExceptions;
using Zoo.Common.DTOs;
using Zoo.Common.Helper;
using Zoo.Common.Models;
using Zoo.Core.Interfaces;

namespace Zoo.Core.Implementations
{
    /// <summary>
    /// Provides Service for calculating the cost of feeding the animals in the zoo.
    /// </summary>
    public class ZooService : IZooService
    {
        private readonly IDataHelper _dataHelper;
        private readonly ILogger<ZooService> _logger;

        public ZooService(IDataHelper dataHelper, ILogger<ZooService> logger)
        {
            _dataHelper = dataHelper;
            _logger = logger;
        }

        /// <summary>
        /// Calculates the total cost of feeding the animals in the zoo for the specified number of days.
        /// </summary>
        /// <param name="numDays">The number of days to calculate the cost for.</param>
        /// <returns>The total cost of feeding the animals in the zoo for the specified number of days.</returns>
        public async Task<CostResponseDto> CalculateCostAsync(int numDays)
        {
            try
            {
                var zooAnimals = await _dataHelper.LoadZooAnimalsAsync();
                var prices = await _dataHelper.LoadPricesAsync();

                decimal foodCostPerDay = CalculateFoodCostPerDay(zooAnimals, prices);

                return new CostResponseDto
                {
                    Cost = foodCostPerDay * numDays
                };
            }
            catch (DataLoadException ex)
            {
                _logger.LogError(ex,ex.Message);
                throw new DataLoadException("An error occurred while calculating the cost. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while calculating the cost of feeding the animals.");
                throw;
            }


        }

        private decimal CalculateFoodCostPerDay(List<Animal> zooAnimals, Dictionary<string, decimal> prices)
        {
            decimal foodCostPerDay = 0;
            foreach (var animal in zooAnimals)
            {
                foodCostPerDay += CalculateAnimalFoodCost(animal, prices);
            }
            return foodCostPerDay;
        }

        private decimal CalculateAnimalFoodCost(Animal animal, Dictionary<string, decimal> prices)
        {
            switch (animal.Species.Type)
            {
                case AnimalType.Carnivore:
                    return prices[Constants.Meat] * animal.Species.FoodRate * animal.Weight;
                case AnimalType.Herbivore:
                    return prices[Constants.Fruit] * animal.Species.FoodRate * animal.Weight;
                case AnimalType.Omnivore:
                    decimal meatCost = prices[Constants.Meat] * animal.Species.FoodRate * animal.Weight * animal.Species.MeatPercentage;
                    decimal fruitCost = prices[Constants.Fruit] * animal.Species.FoodRate * animal.Weight * (1 - animal.Species.MeatPercentage);
                    return meatCost + fruitCost;
                default:
                    _logger.LogError($"Unsupported animal type: {animal.Species.Type}");
                    throw new DataLoadException($"Unsupported animal type: {animal.Species.Type}");
            }
        }
    }
}
