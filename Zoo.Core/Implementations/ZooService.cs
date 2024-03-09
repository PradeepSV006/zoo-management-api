using Zoo.Core.Interfaces;

namespace Zoo.Core.Implementations
{
    /// <summary>
    /// Provides Service for calculating the cost of feeding the animals in the zoo.
    /// </summary>
    public class ZooService : IZooService
    {
        /// <summary>
        /// Calculates the total cost of feeding the animals in the zoo for the specified number of days.
        /// </summary>
        /// <param name="numDays">The number of days to calculate the cost for.</param>
        /// <returns>The total cost of feeding the animals in the zoo for the specified number of days.</returns>
        public decimal CalculateCost(int numDays)
        {
            return 0;
        }
    }
}
