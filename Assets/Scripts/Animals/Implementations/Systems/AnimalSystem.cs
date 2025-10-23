using System.Collections.Generic;
using Animals.Interfaces;
using Common.Interfaces;
using GameLoop.UI;
using PopupTexts.Interfaces;
using Screens.Interfaces;
using UnityEngine;

namespace Animals.Implementations.Systems
{
    public class AnimalSystem : IAnimalSystem
    {
        private IAnimalCreator _animalCreator;
        private IAnimalMover _animalMover;
        private IScreenSystem _screenSystem;
        private IPopupTextSystem _popupTextSystem;

        private List<IAnimalView> _animalViews;
        private int _animalEatenCount;

        public AnimalSystem(IAnimalCreator animalCreator,
            IAnimalMover animalMover,
            IScreenSystem screenSystem,
            IPopupTextSystem popupTextSystem)
        {
            _animalCreator = animalCreator;
            _animalMover = animalMover;
            _screenSystem = screenSystem;
            _popupTextSystem = popupTextSystem;

            _animalViews = new List<IAnimalView>();

            _animalCreator.OnAnimalCreate += AddNewAnimalView;
            _animalCreator.OnAnimalRemove += RemoveAnimalView;
        }

        public void StartSystem()
        {
            _animalCreator.StartCreation();
            _animalMover.StartMove(_animalViews);
        }

        private void AddNewAnimalView(IAnimalView animalView)
        {
            _animalViews.Add(animalView);
            animalView.OnCollisionEnterAction += ProcessCollision;
        }

        private void RemoveAnimalView(IAnimalView animalView)
        {
            _animalViews.Remove(animalView);
            animalView.OnCollisionEnterAction -= ProcessCollision;
        }

        private void ProcessCollision(ICollider collider, Collision collision)
        {
            if (!collision.rigidbody || !collision.rigidbody.TryGetComponent<IAnimalView>(out var otherAnimalView) || !(collider is IAnimalView animalView))
            {
                return;
            }

            if(animalView.AnimalDynamicData.AnimalHuntType == Enums.AnimalHuntType.Predator)
            {
                EatAnimal(otherAnimalView);
            }
        }

        private void EatAnimal(IAnimalView animalView)
        {
            _animalCreator.RemoveAnimal(animalView);

            _animalEatenCount++;
            _screenSystem.GetScreen<GameScreen>().AnimalEatenPanel.SetCountText(_animalEatenCount);
            _popupTextSystem.ShowText(new PopupTexts.Data.PopupTextData()
            {
                Position = animalView.Transform.position,
                PopupTextType = PopupTexts.Enums.PopupTextType.Eat,
            });
        }

    }
}
