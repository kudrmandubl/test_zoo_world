using Locations.Implementations.Views;
using UnityEngine;

namespace Locations.Configs
{
    [CreateAssetMenu(fileName = "LocationConfig", menuName = "Configs/Locations/LocationConfig")]
    public class LocationConfig : ScriptableObject
    {
        [SerializeField] private LocationView _locationViewPrefab;

        public LocationView LocationViewPrefab => _locationViewPrefab;
    }
}
