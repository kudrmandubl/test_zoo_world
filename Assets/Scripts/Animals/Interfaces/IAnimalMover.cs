
using System.Collections.Generic;

namespace Animals.Interfaces
{
    public interface IAnimalMover
    {
        void StartMove(List<IAnimalView> animalViews);
    }
}
