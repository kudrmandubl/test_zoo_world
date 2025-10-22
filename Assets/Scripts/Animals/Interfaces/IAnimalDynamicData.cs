
using Animals.Enums;

namespace Animals.Interfaces
{
    public interface IAnimalDynamicData
    {
        AnimalType AnimalType { get; set; }

        AnimalHuntType AnimalHuntType { get; set; }
    }
}