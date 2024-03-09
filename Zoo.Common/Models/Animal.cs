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
        public string Species { get; set; }
        /// <summary>
        /// Represents the weight of the animal.
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Represents the type of the animal (Carnivore, Herbivore, or Omnivore).
        /// </summary>
        public AnimalType Type { get; set; }
        /// <summary>
        /// Represents the food rate of the animal.
        /// </summary>
        public decimal FoodRate { get; set; }
        /// <summary>
        /// Represents the percentage of meat in the diet of an omnivore animal.
        /// </summary>
        public decimal MeatPercentage { get; set; }
    }

    /// <summary>
    /// Represents the type of an animal (Carnivore, Herbivore, or Omnivore).
    /// </summary>
    public enum AnimalType
    {
        Carnivore,
        Herbivore,
        Omnivore
    }
}
