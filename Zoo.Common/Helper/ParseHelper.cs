
using Zoo.Common.Models;
namespace Zoo.Common.Helper
{
    /// <summary>
    /// Provides helper methods for easing the load data process.
    /// </summary>
    public class ParseHelper : IParseHelper
    {
        /// <summary>
        /// Parses a single line from a CSV file and creates a Species object.
        /// The line is expected to be in the format: "Name,FoodRate,Type[,MeatPercentage]".
        /// </summary>
        /// <param name="line">A line of data in CSV format.</param>
        /// <returns>A Species object representing the parsed data.</returns>
        public Species ParseCsvLine(string line)
        {
                var parts = line.Split(',');
                Species species = new Species
                {
                    Name = parts[0],
                    FoodRate = decimal.Parse(parts[1]),
                    Type = parts[2]?.ToLower() switch
                    {
                        Constants.Meat => AnimalType.Carnivore,
                        Constants.Fruit => AnimalType.Herbivore,
                        Constants.Both => AnimalType.Omnivore,
                        _ => throw new Exception("Invalid animal type"),
                    }
                };
                if (species.Type == AnimalType.Omnivore)
                {
                    species.MeatPercentage = decimal.Parse(parts[3].Trim('%')) / 100;
                }

                return species;
        }

        /// <summary>
        /// Parses a single line from a TXT file and extracts the food type and its corresponding rate.
        /// The line is expected to be in the format: "food=rate".
        /// </summary>
        /// <param name="line">A line of data in TXT format (key-value pair separated by '=').</param>
        /// <param name="food">The parsed food type (output parameter).</param>
        /// <param name="foodRate">The parsed food rate as a decimal (output parameter).</param>
        public void ParseTxtLine(string line, out string food, out decimal foodRate)
        {
                var parts = line.Split('=');
                food = parts[0].ToLower();
                foodRate = decimal.Parse(parts[1]);
        }

    }
}
