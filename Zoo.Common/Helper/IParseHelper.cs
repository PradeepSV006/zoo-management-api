
using Zoo.Common.Models;

namespace Zoo.Common.Helper
{
    /// <summary>
    /// Provides helper methods for easing the load data process.
    /// </summary>
    public interface IParseHelper
    {
        Species ParseCsvLine(string line);
        void ParseTxtLine(string line, out string food, out decimal foodRate);
    }
}
