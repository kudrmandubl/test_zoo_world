using Animals.Implementations.Data;
using Animals.Interfaces;
using Zenject;

namespace Animals.Implementations.Systems
{
    public class AnimalJumpMoveDynamicDataFactory : IFactory<IAnimalJumpMoveDynamicData>
    {
        public IAnimalJumpMoveDynamicData Create()
        {
            return new AnimalJumpMoveDynamicData();
        }
    }
}
