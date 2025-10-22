using Common.Implementations;
using Common.Implementations.Systems;
using Common.Interfaces;
using Zenject;

namespace Common.DI
{
    public class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMonoBehaviourCycle>()
                .To<SimpleMonoBehaviourCycle>()
                .FromNewComponentOnNewGameObject()
                .AsCached();
            Container.Bind<IMainCamera>().To<MainCamera>().AsCached();
        }

    }
}