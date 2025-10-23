using UnityEngine;

namespace Locations.Configs
{
    [CreateAssetMenu(fileName = "LocationsConfig", menuName = "Configs/Locations/LocationsConfig")]
    public class LocationsConfig : ScriptableObject
    {
        [SerializeField] private LocationConfig[] _locationConfigs;

        public LocationConfig[] LocationConfigs => _locationConfigs;
    }
}
