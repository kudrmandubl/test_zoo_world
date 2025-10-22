using System;

namespace Common.Interfaces
{
    public interface IMonoBehaviourCycle
    {
        Action<float> OnUpdate { get; set; }

        Action<float> OnFixedUpdate { get; set; }

        Action<bool> OnApplicationFocusChange { get; set; }
    }
}
