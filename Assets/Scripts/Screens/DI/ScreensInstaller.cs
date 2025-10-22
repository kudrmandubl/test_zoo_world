using Screens.Configs;
using Screens.Implementations.Systems;
using Screens.Interfaces;
using Zenject;

namespace Screens.DI
{
    public class ScreensInstaller : MonoInstaller
    {
        private const string ScreensConfigPath = "Configs/ScreensConfig";
        public override void InstallBindings()
        {
            Container.Bind<ScreensConfig>().FromResource(ScreensConfigPath).AsSingle();
            Container.Bind<IScreenSystem>().To<ScreenSystem>().AsCached();
        }

    }
}