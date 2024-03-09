
namespace Zoo.Common.Configuration
{
    public interface IConfigProvider
    {
        string AnimalsCsvPath { get; }
        string PricesTxtPath { get; }
        string ZooXmlPath { get; }
    }
}
