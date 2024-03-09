namespace Zoo.Common.Models
{
    /// <summary>
    /// Represents an animal in the zoo.
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Represents the name of the animal.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the species of the animal.
        /// </summary>
        public Species Species { get; set; }
        /// <summary>
        /// Represents the weight of the animal.
        /// </summary>
        public decimal Weight { get; set; }
    }
}
