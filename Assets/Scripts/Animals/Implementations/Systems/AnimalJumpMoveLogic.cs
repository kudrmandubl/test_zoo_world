using System.Collections.Generic;
using Animals.Interfaces;
using Common.Interfaces;
using UnityEngine;

namespace Animals.Implementations.Systems
{
    public class AnimalJumpMoveLogic : IAnimalMoveLogic
    {
        private const float JumpAngle = 45f;

        public void MoveAnimals(List<IAnimalView> animalViews, float deltaTime)
        {
            for (int i = 0; i < animalViews.Count; i++)
            {
                var animalView = animalViews[i];
                if (!(animalView.AnimalMoveDynamicData is IAnimalJumpMoveDynamicData animalJumpMoveDynamicData))
                {
                    continue;
                }

                animalJumpMoveDynamicData.JumpTimer += deltaTime;
                if (animalJumpMoveDynamicData.JumpTimer >= animalJumpMoveDynamicData.JumpTime)
                {
                    animalJumpMoveDynamicData.JumpTimer -= animalJumpMoveDynamicData.JumpTime;

                    var radians = JumpAngle * Mathf.Deg2Rad;
                    var initialSpeed = Mathf.Sqrt(animalJumpMoveDynamicData.Distance * Physics.gravity.magnitude / Mathf.Sin(2 * radians));
                    animalView.Rigidbody.linearVelocity = new Vector3(
                        animalView.Transform.forward.x * initialSpeed * Mathf.Cos(radians),
                        initialSpeed * Mathf.Sin(radians),
                        animalView.Transform.forward.z * initialSpeed * Mathf.Cos(radians)
                    );
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