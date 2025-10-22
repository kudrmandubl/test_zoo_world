using UnityEngine;

namespace Screens.Interfaces
{
    public interface IScreen 
    {
        RectTransform RectTransform { get; }

        void SetActive(bool value);
    }
}