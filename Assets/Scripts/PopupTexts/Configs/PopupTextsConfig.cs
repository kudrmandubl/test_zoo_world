using System.Linq;
using PopupTexts.Enums;
using PopupTexts.UI;
using UnityEngine;

namespace PopupTexts.Configs
{
    [CreateAssetMenu(fileName = "PopupTextsConfig", menuName = "Configs/PopupTextsConfig")]
    public class PopupTextsConfig : ScriptableObject
    {
        [SerializeField] private PopupTextPanel _popupTextPanelPrefab;
        [SerializeField] private Vector3 _deltaStartPosition;
        [SerializeField] private Vector3 _deltaMove;
        [SerializeField] private float _scaleInDuration = 0.4f;
        [SerializeField] private float _moveDuration = 1.2f;
        [SerializeField] private float _fadeOutDuration = 0.3f;
        [SerializeField] private PopupTextConfigData[] _popupTextConfigsData;

        public PopupTextPanel PopupTextPanelPrefab => _popupTextPanelPrefab;

        public Vector3 DeltaStartPosition => _deltaStartPosition;

        public Vector3 DeltaMove => _deltaMove;

        public float ScaleInDuration => _scaleInDuration;

        public float MoveDuration => _moveDuration;

        public float FadeOutDuration => _fadeOutDuration;

        public PopupTextConfigData GetPopupTextConfigData(PopupTextType type)
        {
            var data = _popupTextConfigsData.FirstOrDefault(x => x.TextType == type);
            if (data == null)
            {
                Debug.LogError($"Can't find popup text with type = {type}");
            }

            return data;
        }
    }
}
