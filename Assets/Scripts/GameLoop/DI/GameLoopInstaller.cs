using GameLoop.Implementations.Systems;
using GameLoop.Interfaces;
using Zenject;

namespace GameLoop.DI
{
    public class GameLoopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameLoopSystem>().To<GameLoopSystem>().AsCached().NonLazy();
        }

    }
}