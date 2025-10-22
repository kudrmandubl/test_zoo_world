using System;
using System.Collections.Generic;

namespace Screens.Interfaces
{
    public interface IScreenSystem
    {
        Action<IScreen> OnCreateScreen { get; set; }

        List<IScreen> ScreenInstances { get; }

        T GetScreen<T>() where T : IScreen;

        IScreen GetCurrentScreen();

        T ShowScreen<T>(bool showAsSingle = true) where T : IScreen;

        void HideScreen<T>() where T : IScreen;
    }
}