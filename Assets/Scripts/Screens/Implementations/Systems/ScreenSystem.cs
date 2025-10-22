using System;
using System.Collections.Generic;
using Screens.Interfaces;
using Screens.Configs;
using System.Linq;
using UnityEngine;
using IScreen = Screens.Interfaces.IScreen;

namespace Screens.Implementations.Systems
{
    public class ScreenSystem : IScreenSystem
    {
        private ScreensConfig _screensConfig;

        private Transform _canvasTransform;
        private List<IScreen> _screenInstances;
        private Stack<IScreen> _currentScreens;

        public Action<IScreen> OnCreateScreen {  get; set; }

        public List<IScreen> ScreenInstances => _screenInstances;

        public ScreenSystem(ScreensConfig screensConfig) 
        {
            _screensConfig = screensConfig;

            _screenInstances = new List<IScreen>();
            _currentScreens = new Stack<IScreen>();

            _canvasTransform = GameObject.FindAnyObjectByType<Canvas>().transform;
        }

        public T GetScreen<T>() where T : IScreen
        {
            var instance = _screenInstances.FirstOrDefault(x => x is T);
            if(instance != null)
            {
                return (T) instance;
            }

            var prefab = _screensConfig.ScreenPrefabs.FirstOrDefault(x => x is T);
            if (prefab == null)
            {
                Debug.LogError($"Не найден экран {typeof(T)} в списке префабов экранов");
                return default(T);
            }

            // TODO: вынести спаун в другой класс - таким образом уйдёт и явное преобразование в реализации
            var prefabType = (BaseScreen) prefab;

            instance = GameObject.Instantiate(prefabType, _canvasTransform);
            _screenInstances.Add(instance);
            SetActiveScreen(instance, false);

            OnCreateScreen?.Invoke(instance);

            return (T) instance;
        }

        public IScreen GetCurrentScreen()
        {
            return _currentScreens.First();
        }

        public void HideScreen<T>() where T : IScreen
        {
            var screen = GetScreen<T>();
            if (screen == null)
            {
                Debug.LogError($"Не возможно скрыть экран {nameof(T)}, т.к. он не найден");
                return;
            }

            if(GetCurrentScreen() is not T)
            {
                Debug.LogError($"Не возможно скрыть экран {nameof(T)}, т.к. он не последний в очереди показа");
                return;
            }

            _currentScreens.Pop();
            SetActiveScreen(screen, false);
        }

        public T ShowScreen<T>(bool showAsSingle = true) where T : IScreen
        {
            var screen = GetScreen<T>();
            if (screen == null)
            {
                Debug.LogError($"Не возможно показать экран {nameof(T)}");
                return default;
            }

            if (showAsSingle)
            {
                while (_currentScreens.Count > 0)
                {
                    var shownScreen = _currentScreens.Pop();
                    SetActiveScreen(shownScreen, false);
                }
            }
            else
            {
                (screen as BaseScreen).transform.SetAsLastSibling();
            }
            
            _currentScreens.Push(screen);

            SetActiveScreen(screen, true);
            return screen;
        }

        private void SetActiveScreen(IScreen screen, bool value)
        {
            screen.SetActive(value);
        }
    }
}
