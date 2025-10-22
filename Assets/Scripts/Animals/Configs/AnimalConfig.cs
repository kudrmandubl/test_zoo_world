using Animals.Enums;
using Animals.Implementations.Views;
using UnityEngine;

namespace Animals.Configs
{
    public abstract class AnimalConfig : ScriptableObject
    {
        [SerializeField] private AnimalView _prefab;
        [SerializeField] private AnimalType _type;
        [SerializeField] private AnimalHuntType _huntType;

        public AnimalView Prefab => _prefab;

        public AnimalType Type => _type;

        public AnimalHuntType HuntType => _huntType;
    }
}