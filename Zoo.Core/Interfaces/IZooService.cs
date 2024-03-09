
namespace Zoo.Core.Interfaces
{
    /// <summary>
    /// Provides Service for calculating the cost of feeding the animals in the zoo.
    /// </summary>
    public interface IZooService
    {
        decimal CalculateCost(int numDays);

    }
}
