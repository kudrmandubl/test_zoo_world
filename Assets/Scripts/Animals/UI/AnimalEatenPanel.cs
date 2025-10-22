using TMPro;
using UnityEngine;

namespace Animals.UI
{
    public class AnimalEatenPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _countText;

        public void SetCountText(int count)
        {
            _countText.text = count.ToString();
        }
    }
}