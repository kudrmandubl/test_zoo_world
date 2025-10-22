using System.Collections.Generic;
using Animals.Configs;
using Animals.Enums;
using Animals.Interfaces;
using Common.Interfaces;
using UnityEngine;

namespace Animals.Implementations.Systems
{
    public class AnimalMover : IAnimalMover
    {
        private AnimalsConfig _animalsConfig;

        private IMonoBehaviourCycle _monoBehaviourCycle;
        private IMainCamera _mainCamera;
        private List<IAnimalMoveLogic> _animalMoveLogics;

        private List<IAnimalView> _animalViews;

        public AnimalMover(AnimalsConfig animalsConfig, 
            IMonoBehaviourCycle monoBehaviourCycle,
            IMainCamera mainCamera,
            IAnimalCreator animalCreator,
            List<IAnimalMoveLogic> animalMoveLogics)
        {
            _animalsConfig = animalsConfig;

            _monoBehaviourCycle = monoBehaviourCycle;
            _mainCamera = mainCamera;
            _animalMoveLogics = animalMoveLogics;

            _monoBehaviourCycle.OnUpdate += Update;
        }

        public void StartMove(List<IAnimalView> animalViews)
        {
            _animalViews = animalViews;
        }

        private void Update(float deltaTime)
        {
            MoveAnimals(deltaTime);
        }

        private void MoveAnimals(float deltaTime)
        {
            for (int i = 0; i < _animalMoveLogics.Count; i++)
            {
                _animalMoveLogics[i].MoveAnimals(_animalViews, deltaTime);
                _animalMoveLogics[i].ApplyCameraView(_animalViews, _mainCamera);
            }

        }
    }
}