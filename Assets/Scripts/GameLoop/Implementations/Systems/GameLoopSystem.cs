using Animals.Interfaces;
using GameLoop.Interfaces;
using GameLoop.UI;
using Screens.Interfaces;

namespace GameLoop.Implementations.Systems
{
    public class GameLoopSystem : IGameLoopSystem
    {
        private IAnimalSystem _animalSystem;
        private IScreenSystem _screenSystem; 

        public GameLoopSystem(IAnimalSystem animalSystem,
            IScreenSystem screenSystem)
        {
            _animalSystem = animalSystem;
            _screenSystem = screenSystem;

            StartGameLoop();
        }

        public void StartGameLoop()
        {
            _screenSystem.ShowScreen<GameScreen>();
            _animalSystem.StartSystem();
        }

        public void StopGameLoop()
        {
            throw new System.NotImplementedException();
        }
    }
}