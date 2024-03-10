
using Zoo.Common.Models;

namespace Zoo.Common.Helper
{
    /// <summary>
    /// Interface that defines methods for parsing data lines from the files.
    /// </summary>
    public interface IParseHelper
    {
        /// <summary>
        /// Parses a single line from a CSV file and creates a Species object.
        /// </summary>
        /// <param name="line">A line of data in CSV format.</param>
        /// <returns>A Species object representing the parsed data.</returns>
        Species ParseCsvLine(string line);

        /// <summary>
        /// Parses a single line from a TXT file and extracts the food type and its corresponding rate.
        /// </summary>
        /// <param name="line">A line of data in TXT format (key-value pair separated by '=').</param>
        /// <param name="food">The parsed food type (output parameter).</param>
        /// <param name="foodRate">The parsed food rate as a decimal (output parameter).</param>
        void ParseTxtLine(string line, out string food, out decimal foodRate);
    }
}
