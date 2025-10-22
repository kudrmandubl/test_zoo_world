using Animals.Implementations.Data;
using Animals.Interfaces;
using Zenject;

namespace Animals.Implementations.Systems
{
    public class AnimalDynamicDataFactory : IFactory<IAnimalDynamicData>
    {
        public IAnimalDynamicData Create()
        {
            return new AnimalDynamicData();
        }
    }
}
