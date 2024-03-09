using Zoo.Common;
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

        public ZooService(IDataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }

        /// <summary>
        /// Calculates the total cost of feeding the animals in the zoo for the specified number of days.
        /// </summary>
        /// <param name="numDays">The number of days to calculate the cost for.</param>
        /// <returns>The total cost of feeding the animals in the zoo for the specified number of days.</returns>
        public decimal CalculateCost(int numDays)
        {
            var zooAnimals = _dataHelper.LoadZooAnimals();
            var prices = _dataHelper.LoadPrices();

            decimal totalCost = 0;

            foreach (var animal in zooAnimals)
            {
                decimal foodCostPerDay = 0;

                if (animal.Species.Type == AnimalType.Carnivore)
                {
                    foodCostPerDay = prices[Constants.Meat] * animal.Species.FoodRate * animal.Weight;
                }
                else if (animal.Species.Type == AnimalType.Herbivore)
                {
                    foodCostPerDay = prices[Constants.Fruit] * animal.Species.FoodRate * animal.Weight;
                }
                else if (animal.Species.Type == AnimalType.Omnivore)
                {
                    decimal meatCost = prices[Constants.Meat] * animal.Species.FoodRate * animal.Weight * animal.Species.MeatPercentage;
                    decimal fruitCost = prices[Constants.Fruit] * animal.Species.FoodRate * animal.Weight * (1 - animal.Species.MeatPercentage);
                    foodCostPerDay = meatCost + fruitCost;
                }

                totalCost += foodCostPerDay;
            }

            return totalCost * numDays;
        }
    }
}
