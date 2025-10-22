using Common.Interfaces;
using UnityEngine;

namespace Animals.Interfaces
{
    public interface IAnimalView : IBaseView, ICollider
    {
        Rigidbody Rigidbody { get; }

        IAnimalDynamicData AnimalDynamicData { get; set; }

        IAnimalMoveDynamicData AnimalMoveDynamicData { get; set; }
    }
}
