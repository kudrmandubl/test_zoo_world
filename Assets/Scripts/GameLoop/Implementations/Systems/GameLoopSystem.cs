using Animals.Interfaces;
using GameLoop.Interfaces;
using GameLoop.UI;
using PopupTexts.Interfaces;
using Screens.Interfaces;

namespace GameLoop.Implementations.Systems
{
    public class GameLoopSystem : IGameLoopSystem
    {
        private IAnimalSystem _animalSystem;
        private IScreenSystem _screenSystem;
        private IPopupTextSystem _popupTextSystem;

        public GameLoopSystem(IAnimalSystem animalSystem,
            IScreenSystem screenSystem,
            IPopupTextSystem popupTextSystem)
        {
            _animalSystem = animalSystem;
            _screenSystem = screenSystem;
            _popupTextSystem = popupTextSystem;

            StartGameLoop();
        }

        public void StartGameLoop()
        {
            _popupTextSystem.Initialize();

            _screenSystem.ShowScreen<GameScreen>();
            _animalSystem.StartSystem();
        }

        public void StopGameLoop()
        {
            throw new System.NotImplementedException();
        }
    }
}