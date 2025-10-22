using Animals.Implementations.Data;
using Animals.Interfaces;
using Zenject;

namespace Animals.Implementations.Systems
{
    public class AnimalSimpleMoveDynamicDataFactory : IFactory<IAnimalSimpleMoveDynamicData>
    {
        public IAnimalSimpleMoveDynamicData Create()
        {
            return new AnimalSimpleMoveDynamicData();
        }
    }
}
