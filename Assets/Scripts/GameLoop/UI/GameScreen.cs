using Animals.UI;
using Screens.Implementations;
using UnityEngine;

namespace GameLoop.UI
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private AnimalEatenPanel _animalEatenPanel;
        [SerializeField] private Transform _popupTextContainer;

        public AnimalEatenPanel AnimalEatenPanel => _animalEatenPanel;

        public Transform PopupTextContainer => _popupTextContainer;
    }
}
