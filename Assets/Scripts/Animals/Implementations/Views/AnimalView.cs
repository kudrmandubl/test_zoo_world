using System;
using Animals.Interfaces;
using Common.Interfaces;
using Common.Utils;
using UnityEngine;

namespace Animals.Implementations.Views
{
    public class AnimalView : CachedMonoBehaviour, IAnimalView
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        public IAnimalDynamicData AnimalDynamicData { get; set; }

        public IAnimalMoveDynamicData AnimalMoveDynamicData { get; set; }

        public Rigidbody Rigidbody => _rigidbody;

        public Collider Collider => _collider;

        public Action<ICollider, Collision> OnCollisionEnterAction { get; set; }

        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterAction?.Invoke(this, collision);
        }
    }
}