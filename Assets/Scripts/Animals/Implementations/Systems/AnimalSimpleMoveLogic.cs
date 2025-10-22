using System.Collections.Generic;
using Animals.Implementations.Views;
using Animals.Interfaces;
using Common.Interfaces;
using UnityEngine;

namespace Animals.Implementations.Systems
{
    public class AnimalSimpleMoveLogic : IAnimalMoveLogic
    {
        public void MoveAnimals(List<IAnimalView> animalViews, float deltaTime)
        {
            for (int i = 0; i < animalViews.Count; i++)
            {
                var animalView = animalViews[i];
                if(!(animalView.AnimalMoveDynamicData is IAnimalSimpleMoveDynamicData animalSimpleMoveDynamicData))
                {
                    continue;
                }

                animalView.Transform.position += animalView.Transform.forward * animalSimpleMoveDynamicData.Speed * deltaTime;
            }
        }

        public void ApplyCameraView(List<IAnimalView> animalViews, IMainCamera mainCamera)
        {
            for (int i = 0; i < animalViews.Count; i++)
            {
                var animalView = animalViews[i];
                var animalViewportPosition = mainCamera.Camera.WorldToViewportPoint(animalView.Transform.position);
                var forward = animalView.Transform.forward;
                if ((animalViewportPosition.x <= 0 && forward.x < 0) || (animalViewportPosition.x >= 1 && forward.x > 0)
                    || (animalViewportPosition.y <= 0 && forward .z < 0) || (animalViewportPosition.y >= 1 && forward.z > 0))
                {
                    // TODO: может сделать вместо это нормаль по отношению к текущему движению и границе экрана?
                    animalView.Transform.localEulerAngles += Vector3.up * 90;
                }
            }
        }
    }
}