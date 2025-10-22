using UnityEngine;

namespace Animals.Configs
{
    [CreateAssetMenu(fileName = "AnimalsConfig", menuName = "Configs/Animals/AnimalsConfig")]
    public class AnimalsConfig : ScriptableObject
    {
        [SerializeField] private float _minCreationTime = 1f;
        [SerializeField] private float _maxCreationTime = 2f;
        [SerializeField] private AnimalConfig[] _animalConfigs;

        public float MinCreationTime => _minCreationTime;

        public float MaxCreationTime => _maxCreationTime;

        public AnimalConfig[] AnimalConfigs => _animalConfigs;
    }
}
