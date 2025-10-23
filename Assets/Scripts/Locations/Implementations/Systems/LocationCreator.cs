using Common.Interfaces;
using Locations.Configs;
using Locations.Interfaces;
using UnityEngine;

namespace Locations.Implementations.Systems
{
    public class LocationCreator : ILocationCreator
    {
        private IGameContainer _gameContainer;

        private LocationsConfig _locationsConfig;

        public LocationCreator(IGameContainer gameContainer,
            LocationsConfig locationsConfig)
        {
            _gameContainer = gameContainer;

            _locationsConfig = locationsConfig;
        }

        public ILocationView Create()
        {
            var locationView = GameObject.Instantiate(_locationsConfig.LocationConfigs[Random.Range(0, _locationsConfig.LocationConfigs.Length)].LocationViewPrefab, _gameContainer.Container);
            return locationView;
        }
    }
}

