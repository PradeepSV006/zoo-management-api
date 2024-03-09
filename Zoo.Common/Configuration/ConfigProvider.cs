
using Microsoft.Extensions.Configuration;

namespace Zoo.Common.Configuration
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string AnimalsCsvPath => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            _configuration["Data:Path"],
            "Config",
            "animals.csv"
        );
        public string PricesTxtPath => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            _configuration["Data:Path"],
            "Config",
            "prices.txt"
        );
        public string ZooXmlPath => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            _configuration["Data:Path"],
            "zoo.xml"
        );
    }
}
