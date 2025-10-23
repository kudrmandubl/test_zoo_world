using System;
using PopupTexts.Enums;
using UnityEngine;

namespace PopupTexts.Configs
{
    [Serializable]
    public class PopupTextConfigData
    {
        [SerializeField] private PopupTextType _textType;
        [SerializeField] private string _text;
        [SerializeField] private Color _textColor;
        [SerializeField] private float _textScale = 1f;

        public PopupTextType TextType => _textType;

        public string Text => _text;

        public Color TextColor => _textColor;

        public float TextScale => _textScale;
    }
}
