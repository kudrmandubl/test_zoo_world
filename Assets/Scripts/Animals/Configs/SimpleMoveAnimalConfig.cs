using UnityEngine;

namespace Animals.Configs
{
    [CreateAssetMenu(fileName = "SimpleMoveAnimalConfig", menuName = "Configs/Animals/SimpleMoveAnimalConfig")]
    public class SimpleMoveAnimalConfig : AnimalConfig
    {
        [SerializeField] private float _speed = 10;

        public float Speed => _speed;
    }
}