using Animals.Configs;

namespace Animals.Interfaces
{
    public interface IAnimalPool
    {
        IAnimalView GetFreeElement(AnimalConfig animalConfig);

        void Free(IAnimalView element);
    }
}