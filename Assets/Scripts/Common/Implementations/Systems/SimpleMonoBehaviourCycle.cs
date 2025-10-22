using System;
using Common.Interfaces;
using UnityEngine;

namespace Common.Implementations.Systems
{
    public class SimpleMonoBehaviourCycle : MonoBehaviour, IMonoBehaviourCycle
    {
        public Action<float> OnUpdate { get; set; }

        public Action<float> OnFixedUpdate { get; set; }

        public Action<bool> OnApplicationFocusChange { get; set; }

        public static SimpleMonoBehaviourCycle CreateInstance()
        {
            var go = new GameObject($"{nameof(SimpleMonoBehaviourCycle)}");
            return go.AddComponent<SimpleMonoBehaviourCycle>();
        }

        private void Update()
        {
            OnUpdate?.Invoke(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke(Time.fixedDeltaTime);
        }

        private void OnApplicationFocus(bool focus)
        {
            OnApplicationFocusChange?.Invoke(focus);
        }
    }
}
