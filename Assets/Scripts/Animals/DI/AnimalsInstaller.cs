using System.Collections.Generic;
using Animals.Configs;
using Animals.Enums;
using Animals.Implementations.Systems;
using Animals.Implementations.Views;
using Animals.Interfaces;
using Zenject;

namespace Animals.DI
{
    public class AnimalsInstaller : MonoInstaller
    {
        private const string AnimalsConfigPath = "Configs/AnimalsConfig";

        public override void InstallBindings()
        {
            Container.Bind<AnimalsConfig>().FromResource(AnimalsConfigPath).AsSingle();
            Container.Bind<IFactory<IAnimalDynamicData>>().To<AnimalDynamicDataFactory>().AsCached();
            Container.Bind<IFactory<IAnimalSimpleMoveDynamicData>>().To<AnimalSimpleMoveDynamicDataFactory>().AsCached();
            Container.Bind<IFactory<IAnimalJumpMoveDynamicData>>().To<AnimalJumpMoveDynamicDataFactory>().AsCached();
            Container.Bind<IAnimalPool>().To<AnimalPool>().AsCached();
            Container.Bind<IAnimalCreator>().To<AnimalCreator>().AsCached();
            Container.Bind<IAnimalMoveLogic>().To<AnimalSimpleMoveLogic>().AsCached();
            Container.Bind<IAnimalMoveLogic>().To<AnimalJumpMoveLogic>().AsCached();
            Container.Bind<IAnimalMover>().To<AnimalMover>().AsCached();
            Container.Bind<IAnimalSystem>().To<AnimalSystem>().AsCached();
        }

    }
}