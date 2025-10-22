using System.Collections.Generic;
using Animals.Interfaces;
using Common.Interfaces;
using UnityEngine;

namespace Animals.Implementations.Systems
{
    public class AnimalJumpMoveLogic : IAnimalMoveLogic
    {
        private const float JumpForceCoef = 35;

        public void MoveAnimals(List<IAnimalView> animalViews, float deltaTime)
        {
            for (int i = 0; i < animalViews.Count; i++)
            {
                var animalView = animalViews[i];
                if(!(animalView.AnimalMoveDynamicData is IAnimalJumpMoveDynamicData animalJumpMoveDynamicData))
                {
                    continue;
                }

                animalJumpMoveDynamicData.JumpTimer += deltaTime;
                if(animalJumpMoveDynamicData.JumpTimer >= animalJumpMoveDynamicData.JumpTime)
                {
                    animalJumpMoveDynamicData.JumpTimer -= animalJumpMoveDynamicData.JumpTime;
                    animalView.Rigidbody.AddForce((animalView.Transform.forward + Vector3.up) * animalView.Rigidbody.mass * animalJumpMoveDynamicData.Distance * JumpForceCoef);
                }
            }
        }

        public void ApplyCameraView(List<IAnimalView> animalViews, IMainCamera mainCamera)
        {
            for (int i = 0; i < animalViews.Count; i++)
            {
                var animalView = animalViews[i];
                var animalViewportPosition = mainCamera.Camera.WorldToViewportPoint(animalView.Transform.position);
                var linearVelocity = animalView.Rigidbody.linearVelocity;
                if ((animalViewportPosition.x <= 0 && linearVelocity.x < 0) || (animalViewportPosition.x >= 1 && linearVelocity.x > 0))
                {
                    linearVelocity.x = -linearVelocity.x; 
                    animalView.Rigidbody.linearVelocity = linearVelocity;
                }
                else if ((animalViewportPosition.y <= 0 && linearVelocity.z < 0) || (animalViewportPosition.y >= 1 && linearVelocity.z > 0))
                {
                    linearVelocity.z = -linearVelocity.z;
                    animalView.Rigidbody.linearVelocity = linearVelocity;
                }
            }
        }
    }
}