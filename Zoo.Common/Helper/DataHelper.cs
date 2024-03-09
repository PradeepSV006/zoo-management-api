using System.Xml;
using System.Xml.Linq;
using Zoo.Common.Configuration;
using Zoo.Common.Models;

namespace Zoo.Common.Helper
{
    /// <summary>
    /// Provides helper methods for loading data related to the zoo.
    /// </summary>
    public class DataHelper : IDataHelper
    {
        private readonly IConfigProvider _configProvider;
        private readonly IParseHelper _parseHelper;

        public DataHelper(IConfigProvider configProvider, IParseHelper parseHelper)
        {
            _configProvider = configProvider;
            _parseHelper = parseHelper;
        }

        /// <summary>
        /// Loads information about animals species and their rates from the animals.csv file.
        /// </summary>
        /// <returns>A list of animals loaded from the animals.csv file.</returns>
        public async Task<List<Species>> LoadSpeciesAsync()
        {
            try
            {
                List<Species> speciesList = new List<Species>();

                using (var stream = File.OpenRead(_configProvider.AnimalsCsvPath))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        speciesList.Add(_parseHelper.ParseCsvLine(line));
                    }
                }

                return speciesList;
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
            catch (FormatException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Loads prices for meat and fruit from the prices.txt file.
        /// </summary>
        /// <returns>A dictionary containing prices for meat and fruit.</returns>
        public async Task<Dictionary<string, decimal>> LoadPricesAsync()
        {
            try
            {
                var prices = new Dictionary<string, decimal>();

                using(var stream = File.OpenRead(_configProvider.PricesTxtPath))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    string food;
                    decimal rate;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        _parseHelper.ParseTxtLine(line, out food, out rate);
                        prices.Add(food, rate);
                    }
                }
                return prices;
            }

            catch (FileNotFoundException e)
            {
                throw;
            }
            catch (FormatException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Loads information about animals present in the zoo from the zoo.xml file.
        /// </summary>
        /// <returns>A list of animals present in the zoo loaded from the zoo.xml file.</returns>
        public async Task<List<Animal>> LoadZooAnimalsAsync()
        {
            try
            {
                var species = await LoadSpeciesAsync();
                var speciesDictByName = species.ToDictionary(s => s.Name, s => s);
                using (var stream = File.OpenRead(_configProvider.ZooXmlPath))
                {
                    XDocument doc = await XDocument.LoadAsync(stream, LoadOptions.None, default);

                    var zooAnimals = doc.Descendants(Constants.XmlZoo).Elements()?.Elements()
                    .Select(animalElement =>
                    {
                        string animalName = animalElement.Attribute(Constants.XmlName).Value;
                        decimal animalWeight = decimal.Parse(animalElement.Attribute(Constants.Kilogram).Value);
                        string animalSpeciesName = animalElement.Name.LocalName;
                        var speciesConfig = speciesDictByName.TryGetValue(animalSpeciesName, out var species) ? species : null;
                        return speciesConfig != null ? new Animal { Name = animalName, Weight = animalWeight, Species = speciesConfig } : throw new Exception();
                    })
                    .Where(animal => animal != null)
                    .ToList();

                    return zooAnimals;
                }
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
            catch (FormatException e)
            {
                throw;
            }

            catch (XmlException e)
            {
                throw;
            }

            catch (Exception e)
            {
                throw;
            }
        }
    }
}
