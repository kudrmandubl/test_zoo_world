using System.Collections.Generic;
using Common.Interfaces;

namespace Animals.Interfaces
{
    public interface IAnimalMoveLogic
    {
        void MoveAnimals(List<IAnimalView> animalViews, float deltaTime);

        void ApplyCameraView(List<IAnimalView> animalViews, IMainCamera mainCamera);
    }
}
