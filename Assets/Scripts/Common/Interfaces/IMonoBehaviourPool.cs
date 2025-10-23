using UnityEngine;

namespace Common.Interfaces
{
    public interface IMonoBehaviourPool<T> where T : Component
    {
        T GetFreeElement();

        void Free(T element);

        void SetPrefab(T prefab);

        void SetContainer(Transform container);
    }
}