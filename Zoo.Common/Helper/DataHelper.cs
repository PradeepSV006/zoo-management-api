using Zoo.Common.Models;

namespace Zoo.Common.Helper
{
    /// <summary>
    /// Provides helper methods for loading data related to the zoo.
    /// </summary>
    public class DataHelper : IDataHelper
    {
        /// <summary>
        /// Loads information about animals species and their rates from the animals.csv file.
        /// </summary>
        /// <returns>A list of animals loaded from the animals.csv file.</returns>
        public List<Animal> LoadAnimals()
        {
            return new List<Animal>();
        }

        /// <summary>
        /// Loads prices for meat and fruit from the prices.txt file.
        /// </summary>
        /// <returns>A dictionary containing prices for meat and fruit.</returns>
        public Dictionary<string, decimal> LoadPrices()
        {
            return new Dictionary<string, decimal>();
        }

        /// <summary>
        /// Loads information about animals present in the zoo from the zoo.xml file.
        /// </summary>
        /// <returns>A list of animals present in the zoo loaded from the zoo.xml file.</returns>
        public List<Animal> LoadZooAnimals()
        {
            return new List<Animal>();
        }
    }
}
