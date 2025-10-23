using Common.Utils;
using TMPro;
using UnityEngine;

namespace PopupTexts.UI
{
    public class PopupTextPanel : CachedMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _popupText;
        [SerializeField] private CanvasGroup _canvasGroup;

        public CanvasGroup CanvasGroup => _canvasGroup;

        public void SetText(string text)
        {
            _popupText.text = text;
        }

        public void SetColor(Color color)
        {
            _popupText.color = color;
        }

        public void SetScale(float scale)
        {
            _popupText.transform.localScale = Vector3.one * scale;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}