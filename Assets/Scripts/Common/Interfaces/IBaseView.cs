using UnityEngine;

namespace Common.Interfaces
{
    public interface IBaseView
    {
        Transform Transform { get; }
        GameObject GameObject { get; }
    }
}