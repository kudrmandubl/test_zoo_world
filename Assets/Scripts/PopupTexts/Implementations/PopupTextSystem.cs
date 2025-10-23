using System.Collections.Generic;
using PopupTexts.Configs;
using PopupTexts.Data;
using PopupTexts.Interfaces;
using DG.Tweening;
using UnityEngine;
using Common.Interfaces;
using PopupTexts.UI;
using Screens.Interfaces;
using GameLoop.UI;

namespace PopupTexts.Implementations
{
    public class PopupTextSystem : IPopupTextSystem
    {
        private PopupTextsConfig _popupTextConfig;

        private IMonoBehaviourPool<PopupTextPanel> _popupTextPanelPool;
        private IScreenSystem _screenSystem;
        private IMainCamera _mainCamera;

        public PopupTextSystem(PopupTextsConfig popupTextConfig,
            IMonoBehaviourPool<PopupTextPanel> popupTextPanelPool,
            IScreenSystem screenSystem,
            IMainCamera mainCamera)
        {
            _popupTextConfig = popupTextConfig;
            _popupTextPanelPool = popupTextPanelPool;
            _screenSystem = screenSystem;
            _mainCamera = mainCamera;

            _popupTextPanelPool.SetPrefab(_popupTextConfig.PopupTextPanelPrefab);
        }

        public void Initialize()
        {
            _popupTextPanelPool.SetContainer(_screenSystem.GetScreen<GameScreen>().PopupTextContainer);
        }

        public void ShowText(PopupTextData textData)
        {
            var popupTextPanel = _popupTextPanelPool.GetFreeElement();
            popupTextPanel.SetActive(true);

            var showPosition = _mainCamera.Camera.WorldToScreenPoint(textData.Position) + _popupTextConfig.DeltaStartPosition;
            popupTextPanel.Transform.position = showPosition; 
            
            var popupTextConfigData = _popupTextConfig.GetPopupTextConfigData(textData.PopupTextType);

            popupTextPanel.CanvasGroup.alpha = 1;
            popupTextPanel.SetText(popupTextConfigData.Text);
            popupTextPanel.SetColor(popupTextConfigData.TextColor);
            popupTextPanel.SetScale(popupTextConfigData.TextScale);

            var startScale = popupTextPanel.transform.localScale;
            popupTextPanel.transform.localScale = Vector3.zero;
            var seq = DOTween.Sequence();
            seq.Append(popupTextPanel.transform.DOScale(startScale.x, _popupTextConfig.ScaleInDuration).SetEase(Ease.OutBack));
            seq.Insert(0f, popupTextPanel.transform.DOLocalMove(popupTextPanel.transform.localPosition + _popupTextConfig.DeltaMove, _popupTextConfig.MoveDuration).SetEase(Ease.OutQuad));
            seq.Insert(seq.Duration() - _popupTextConfig.FadeOutDuration, popupTextPanel.CanvasGroup.DOFade(0, _popupTextConfig.FadeOutDuration).SetEase(Ease.Linear));
            seq.AppendCallback(() =>
            {
                _popupTextPanelPool.Free(popupTextPanel);
                popupTextPanel.SetActive(false);
            });
        }
    }
}
