using Common.Interfaces;
using UnityEngine;

namespace Common.Implementations.Systems.Pools
{
    public class MonoBehaviourPool<T> : BasePool<T>, IMonoBehaviourPool<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Transform _container;

        public void SetPrefab(T prefab)
        {
            _prefab = prefab;
        }

        public void SetContainer(Transform container)
        {
            _container = container;
        }

        protected override T GetNew()
        {
            return GameObject.Instantiate(_prefab, _container);
        }
    }
}