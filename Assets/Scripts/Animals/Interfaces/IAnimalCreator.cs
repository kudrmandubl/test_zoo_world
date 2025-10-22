using System;
using System.Collections.Generic;

namespace Animals.Interfaces
{
    public interface IAnimalCreator
    {
        List<IAnimalView> AnimalViews { get; }

        Action<IAnimalView> OnAnimalCreate { get; set; }

        Action<IAnimalView> OnAnimalRemove { get; set; }

        void StartCreation();

        void RemoveAnimal(IAnimalView animalView);
    }
}