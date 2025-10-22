
namespace Animals.Interfaces
{
    public interface IAnimalJumpMoveDynamicData : IAnimalMoveDynamicData
    {
        float JumpTime { get; set; }

        float Distance { get; set; }

        float JumpTimer { get; set; }
    }
}