using PopupTexts.Enums;
using UnityEngine;

namespace PopupTexts.Data
{
    public struct PopupTextData
    {
        public string Text {  get; set; }
        
        public Vector3 Position { get; set; }
        
        public PopupTextType PopupTextType { get; set; }
    }
}
