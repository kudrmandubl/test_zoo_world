
using Animals.Interfaces;

namespace Animals.Implementations.Data
{
    public class AnimalJumpMoveDynamicData : IAnimalJumpMoveDynamicData
    {
        public float JumpTime { get; set; }

        public float Distance { get; set; }

        public float JumpTimer { get; set; }
    }
}