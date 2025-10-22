using UnityEngine;

namespace Animals.Configs
{
    [CreateAssetMenu(fileName = "JumpMoveAnimalConfig", menuName = "Configs/Animals/JumpMoveAnimalConfig")]
    public class JumpMoveAnimalConfig : AnimalConfig
    {
        [SerializeField] private float _jumpTime = 1f;
        [SerializeField] private float _distance = 10;

        public float JumpTime => _jumpTime;

        public float Distance => _distance;
    }
}