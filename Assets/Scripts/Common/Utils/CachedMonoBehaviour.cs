using UnityEngine;

namespace Common.Utils
{
    public class CachedMonoBehaviour : MonoBehaviour
    {
        private Transform _transform;

        public Transform Transform
        {
            get
            {
                if (!_transform)
                {
                    _transform = transform;
                }

                return _transform;
            }
        }

        public GameObject GameObject => gameObject;
    }
}