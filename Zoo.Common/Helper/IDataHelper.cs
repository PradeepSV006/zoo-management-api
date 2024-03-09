using Zoo.Common.Models;

namespace Zoo.Common.Helper
{
    /// <summary>
    /// Provides helper methods for loading data related to the zoo.
    /// </summary>
    public interface IDataHelper
    {
        List<Animal> LoadAnimals();
        Dictionary<string, decimal> LoadPrices();
        List<Animal> LoadZooAnimals();
    }
}
