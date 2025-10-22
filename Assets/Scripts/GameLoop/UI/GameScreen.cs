using Animals.UI;
using Screens.Implementations;
using UnityEngine;

namespace GameLoop.UI
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private AnimalEatenPanel _animalEatenPanel;

        public AnimalEatenPanel AnimalEatenPanel => _animalEatenPanel;
    }
}
