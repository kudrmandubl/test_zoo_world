using System.Collections.Generic;

namespace Common.Implementations.Systems.Pools
{
    public abstract class BasePool<T>
    {
        private Dictionary<T, bool> _elementToFreePairs;

        protected BasePool()
        {
            _elementToFreePairs = new Dictionary<T, bool>();
        }

        public T GetFreeElement()
        {
            foreach (var pair in _elementToFreePairs)
            {
                if (pair.Value)
                {
                    _elementToFreePairs[pair.Key] = false;
                    return pair.Key;
                }
            }

            var newElement = GetNew();
            _elementToFreePairs.Add(newElement, false);

            return newElement;
        }

        public void Free(T element)
        {
            _elementToFreePairs[element] = true;
        }

        protected abstract T GetNew();
    }
}