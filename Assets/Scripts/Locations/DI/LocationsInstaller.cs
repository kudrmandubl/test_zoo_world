using Locations.Configs;
using Locations.Implementations.Systems;
using Locations.Interfaces;
using Zenject;

namespace Locations.DI
{
    public class LocationsInstaller : MonoInstaller
    {
        private const string LocationsConfigPath = "Configs/LocationsConfig";

        public override void InstallBindings()
        {
            Container.Bind<LocationsConfig>().FromResource(LocationsConfigPath).AsSingle();
            Container.Bind<ILocationCreator>().To<LocationCreator>().AsCached();
        }
    }
}