using Screens.Interfaces;
using UnityEngine;

namespace Screens.Implementations
{
    public class BaseScreen : MonoBehaviour, IScreen
    {
        private RectTransform _rectTransform;

        public RectTransform RectTransform 
        {
            get
            {
                if (!_rectTransform)
                {
                    _rectTransform = GetComponent<RectTransform>();
                }
                return _rectTransform;
            }
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
