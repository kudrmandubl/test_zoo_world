using Animals.Interfaces;
using GameLoop.Interfaces;
using GameLoop.UI;
using Locations.Implementations.Systems;
using Locations.Interfaces;
using PopupTexts.Interfaces;
using Screens.Interfaces;

namespace GameLoop.Implementations.Systems
{
    public class GameLoopSystem : IGameLoopSystem
    {
        private IAnimalSystem _animalSystem;
        private IScreenSystem _screenSystem;
        private IPopupTextSystem _popupTextSystem;
        private ILocationCreator _locationCreator;

        public GameLoopSystem(IAnimalSystem animalSystem,
            IScreenSystem screenSystem,
            IPopupTextSystem popupTextSystem,
            ILocationCreator locationController)
        {
            _animalSystem = animalSystem;
            _screenSystem = screenSystem;
            _popupTextSystem = popupTextSystem;
            _locationCreator = locationController;

            StartGameLoop();
        }

        public void StartGameLoop()
        {
            _popupTextSystem.Initialize();

            _locationCreator.Create();
            _screenSystem.ShowScreen<GameScreen>();
            _animalSystem.StartSystem();
        }

        public void StopGameLoop()
        {
            throw new System.NotImplementedException();
        }
    }
}