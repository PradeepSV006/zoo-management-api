
using Microsoft.Extensions.Configuration;

namespace Zoo.Common.Configuration
{
    /// <summary>
    /// Class responsible for providing configuration paths for data files used in the application.
    /// </summary>
    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the ConfigProvider class.
        /// </summary>
        /// <param name="configuration">An instance of IConfiguration used to access configuration settings.</param>
        public ConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the full path to the animals.csv file based on the configuration settings.
        /// </summary>
        public string AnimalsCsvPath => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            _configuration["Data:Path"],
            "Config",
            "animals.csv"
        );
        /// <summary>
        /// Gets the full path to the prices.txt file based on the configuration settings.
        /// </summary>
        public string PricesTxtPath => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            _configuration["Data:Path"],
            "Config",
            "prices.txt"
        );
        /// <summary>
        /// Gets the full path to the zoo.xml file based on the configuration settings.
        /// </summary>
        public string ZooXmlPath => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            _configuration["Data:Path"],
            "zoo.xml"
        );
    }
}
