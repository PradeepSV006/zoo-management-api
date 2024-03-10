
namespace Zoo.Common.DTOs
{
    /// <summary>
    /// Represents the response of the Cost API.
    /// </summary>
    public class CostResponseDto
    {
        /// <summary>
        /// Represents the Cost needed to feed the animals for 'n' days.
        /// </summary>
        public decimal Cost { get; set; }
    }
}
