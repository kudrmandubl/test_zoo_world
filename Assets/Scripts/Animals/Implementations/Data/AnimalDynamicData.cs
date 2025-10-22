using Animals.Enums;
using Animals.Interfaces;

namespace Animals.Implementations.Data
{
    public class AnimalDynamicData : IAnimalDynamicData
    {
        public AnimalType AnimalType { get; set; }

        public AnimalHuntType AnimalHuntType { get; set; }
    }
}