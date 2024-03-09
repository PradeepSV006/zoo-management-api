using Zoo.Common.Models;

namespace Zoo.Common.Helper
{
    /// <summary>
    /// Provides helper methods for loading data related to the zoo.
    /// </summary>
    public interface IDataHelper
    {
        Task<List<Species>> LoadSpeciesAsync();
        Task<Dictionary<string, decimal>> LoadPricesAsync();
        Task<List<Animal>> LoadZooAnimalsAsync();
    }
}
