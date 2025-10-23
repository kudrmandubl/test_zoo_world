using Common.Implementations.Systems.Pools;
using Common.Interfaces;
using PopupTexts.Configs;
using PopupTexts.Implementations;
using PopupTexts.Interfaces;
using PopupTexts.UI;
using Zenject;

namespace PopupTexts.DI
{
    public class PopupTextsInstaller : MonoInstaller
    {
        private const string PopupTextsConfigPath = "Configs/PopupTextsConfig";
        public override void InstallBindings()
        {
            Container.Bind<PopupTextsConfig>().FromResource(PopupTextsConfigPath).AsSingle();
            Container.Bind<IMonoBehaviourPool<PopupTextPanel>>().To<MonoBehaviourPool<PopupTextPanel>>().AsCached();
            Container.Bind<IPopupTextSystem>().To<PopupTextSystem>().AsCached();
        }
    }
}