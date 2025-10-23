using System.Collections.Generic;
using Animals.Configs;
using Animals.Enums;
using Animals.Interfaces;
using Common.Implementations.Systems;
using Common.Interfaces;
using UnityEngine;
using Zenject;
using static UnityEditor.Rendering.FilterWindow;

namespace Animals.Implementations.Systems
{
    public class AnimalPool : IAnimalPool
    {
        private IFactory<IAnimalDynamicData> _animalDynamicDataFactory;
        private IFactory<IAnimalSimpleMoveDynamicData> _animalSimpleMoveDynamicDataFactory;
        private IFactory<IAnimalJumpMoveDynamicData> _animalJumpMoveDynamicDataFactory;
        private IGameContainer _gameContainer;

        private Dictionary<AnimalType, IAnimalView> _typeToPrefabPairs;
        private Dictionary<IAnimalView, bool> _elementToFreePairs;
        private Transform _container;

        public AnimalPool(AnimalsConfig animalsConfig, 
             IFactory<IAnimalDynamicData> animalDynamicDataFactory,
             IFactory<IAnimalSimpleMoveDynamicData> animalSimpleMoveDynamicDataFactory,
             IFactory<IAnimalJumpMoveDynamicData> animalJumpMoveDynamicDataFactory,
             IGameContainer gameContainer)
        {
            _animalDynamicDataFactory = animalDynamicDataFactory;
            _animalSimpleMoveDynamicDataFactory = animalSimpleMoveDynamicDataFactory;
            _animalJumpMoveDynamicDataFactory = animalJumpMoveDynamicDataFactory;
            _gameContainer = gameContainer;

            var typeToPrefabPairs = new Dictionary<AnimalType, IAnimalView>();
            for (int i = 0; i < animalsConfig.AnimalConfigs.Length; i++)
            {
                var animalConfig = animalsConfig.AnimalConfigs[i];
                typeToPrefabPairs.Add(animalConfig.Type, animalConfig.Prefab);
            }

            _typeToPrefabPairs = typeToPrefabPairs;
            _container = new GameObject(nameof(AnimalPool)).transform;
            _container.SetParent(_gameContainer.Container);

            _elementToFreePairs = new Dictionary<IAnimalView, bool>();
        }

        public IAnimalView GetFreeElement(AnimalConfig animalConfig)
        {
            foreach (var pair in _elementToFreePairs)
            {
                if (pair.Key.AnimalDynamicData.AnimalType == animalConfig.Type && pair.Value)
                {
                    _elementToFreePairs[pair.Key] = false;
                    pair.Key.GameObject.SetActive(true);
                    return pair.Key;
                }
            }

            var newElement = GetNew(animalConfig);
            _elementToFreePairs.Add(newElement, false);

            return newElement;
        }

        public void Free(IAnimalView element)
        {
            _elementToFreePairs[element] = true;
            element.Transform.SetParent(_container);
            element.GameObject.SetActive(false);
        }

        private IAnimalView GetNew(AnimalConfig animalConfig)
        {
            if (!_typeToPrefabPairs.TryGetValue(animalConfig.Type, out var prefab))
            {
                Debug.LogError($"Can't find animal with type {animalConfig.Type}");
                return null;
            }

            if (animalConfig.HuntType == AnimalHuntType.None)
            {
                Debug.LogError($"Can't create animal with hunt type {animalConfig.HuntType}");
                return null;
            }

            var newElement = GameObject.Instantiate(prefab.GameObject, _container).GetComponent<IAnimalView>();
            newElement.AnimalDynamicData = _animalDynamicDataFactory.Create();
            newElement.AnimalDynamicData.AnimalType = animalConfig.Type;
            newElement.AnimalDynamicData.AnimalHuntType = animalConfig.HuntType;

            if (animalConfig is SimpleMoveAnimalConfig simpleMoveAnimalConfig)
            {
                var dynamicData = _animalSimpleMoveDynamicDataFactory.Create();
                newElement.AnimalMoveDynamicData = dynamicData;
                dynamicData.Speed = simpleMoveAnimalConfig.Speed;
            }
            else if (animalConfig is JumpMoveAnimalConfig jumpMoveAnimalConfig)
            {
                var dynamicData = _animalJumpMoveDynamicDataFactory.Create();
                newElement.AnimalMoveDynamicData = dynamicData;
                dynamicData.JumpTime = jumpMoveAnimalConfig.JumpTime;
                dynamicData.Distance = jumpMoveAnimalConfig.Distance;
            }
            else
            {
                Debug.LogError($"Can't create animal with config {animalConfig}");
                return null;
            }


            return newElement;
        }
    }
}