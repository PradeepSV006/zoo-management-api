
namespace Zoo.Common.Configuration
{
    /// <summary>
    /// Interface that defines properties for accessing configuration paths for data files.
    /// </summary>
    public interface IConfigProvider
    {
        /// <summary>
        /// Gets the full path to the animals.csv file.
        /// </summary>
        string AnimalsCsvPath { get; }

        /// <summary>
        /// Gets the full path to the prices.txt file.
        /// </summary>
        string PricesTxtPath { get; }

        /// <summary>
        /// Gets the full path to the zoo.xml file.
        /// </summary>
        string ZooXmlPath { get; }
    }
}
