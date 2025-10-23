using System.Collections.Generic;
using PopupTexts.Data;

namespace PopupTexts.Interfaces
{
    public interface IPopupTextSystem
    {
        public void Initialize();

        void ShowText(PopupTextData textData);
    }
}