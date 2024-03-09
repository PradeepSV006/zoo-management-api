
using Zoo.Common.Models;
namespace Zoo.Common.Helper
{
    /// <summary>
    /// Provides helper methods for easing the load data process.
    /// </summary>
    public class ParseHelper : IParseHelper
    {
        public Species ParseCsvLine(string line)
        {
            try
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
            catch (FormatException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public void ParseTxtLine(string line, out string food, out decimal foodRate)
        {
            try
            {
                var parts = line.Split('=');
                food = parts[0].ToLower();
                foodRate = decimal.Parse(parts[1]);
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

    }
}
