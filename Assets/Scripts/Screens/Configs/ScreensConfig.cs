using System.Collections.Generic;
using Screens.Implementations;
using UnityEngine;

namespace Screens.Configs
{
    [CreateAssetMenu(fileName = "ScreensConfig", menuName = "Configs/ScreensConfig")]
    public class ScreensConfig : ScriptableObject
    {
        [SerializeField] private List<BaseScreen> _screenPrefabs;

        public List<BaseScreen> ScreenPrefabs => _screenPrefabs;
    }
}