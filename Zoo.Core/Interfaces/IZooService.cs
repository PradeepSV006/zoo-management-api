
using Zoo.Common.DTOs;

namespace Zoo.Core.Interfaces
{
    /// <summary>
    /// Provides Service for calculating the cost of feeding the animals in the zoo.
    /// </summary>
    public interface IZooService
    {
        Task<CostResponseDto> CalculateCostAsync(int numDays);

    }
}
