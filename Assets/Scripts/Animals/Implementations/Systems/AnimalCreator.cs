using System;
using System.Collections.Generic;
using Animals.Configs;
using Animals.Enums;
using Animals.Interfaces;
using Common.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals.Implementations.Systems
{
    public class AnimalCreator : IAnimalCreator
    {
        private AnimalsConfig _animalsConfig;

        private IAnimalPool _animalPool;
        private IMonoBehaviourCycle _monoBehaviourCycle;
        private IMainCamera _mainCamera;

        private AnimalConfig[] _possibleAnimalConfigs;
        private List<IAnimalView> _animalViews;

        private bool _isStarted;
        private float _creationTimer;
        private float _currentCreationTime;

        public List<IAnimalView> AnimalViews => _animalViews;

        public Action<IAnimalView> OnAnimalCreate { get; set; }

        public Action<IAnimalView> OnAnimalRemove{ get; set; }

        public AnimalCreator(AnimalsConfig animalsConfig, 
            IAnimalPool animalPool,
            IMonoBehaviourCycle monoBehaviourCycle,
            IMainCamera mainCamera)
        {
            _animalsConfig = animalsConfig;

            _animalPool = animalPool;
            _monoBehaviourCycle = monoBehaviourCycle;
            _mainCamera = mainCamera;

            _monoBehaviourCycle.OnUpdate += Update;

            _possibleAnimalConfigs = new AnimalConfig[_animalsConfig.AnimalConfigs.Length];
            for (int i = 0; i < _animalsConfig.AnimalConfigs.Length; i++)
            {
                _possibleAnimalConfigs[i] = _animalsConfig.AnimalConfigs[i];
            }

            _animalViews = new List<IAnimalView>();

            SetNewCreationTime();
        }

        public void StartCreation()
        {
            _isStarted = true;
        }

        public void RemoveAnimal(IAnimalView animalView)
        {
            _animalPool.Free(animalView);
            OnAnimalRemove?.Invoke(animalView);
        }

        private void Update(float deltaTime)
        {
            if (!_isStarted)
            {
                return;
            }

            CreateAnimal(deltaTime);
        }

        private void CreateAnimal(float deltaTime)
        {
            _creationTimer += deltaTime;
            if (_creationTimer >= _currentCreationTime)
            {
                _creationTimer = 0;
                SetNewCreationTime();
                CreateAnimal();
            }
        }

        private void SetNewCreationTime()
        {
            _currentCreationTime = Random.Range(_animalsConfig.MinCreationTime, _animalsConfig.MaxCreationTime);
        }

        private void CreateAnimal()
        {
            var randomAnimalConfig = _possibleAnimalConfigs[Random.Range(0, _possibleAnimalConfigs.Length)];
            var animal = _animalPool.GetFreeElement(randomAnimalConfig);
            _animalViews.Add(animal);

            var randomScreenPosition = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
            var cameraRay = _mainCamera.Camera.ScreenPointToRay(randomScreenPosition);
            Physics.Raycast(cameraRay, out var raycastResult);
            var randomAnimalPosition = raycastResult.point;
            animal.Transform.position = randomAnimalPosition;

            animal.Transform.localEulerAngles = new Vector3(0,Random.Range(0, 360),0);

            OnAnimalCreate?.Invoke(animal);
        }
    }
}