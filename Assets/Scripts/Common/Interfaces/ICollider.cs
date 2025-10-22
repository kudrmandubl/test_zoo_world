using System;
using UnityEngine;

namespace Common.Interfaces
{
    public interface ICollider
    {
        Collider Collider { get; }

        Action<ICollider, Collision> OnCollisionEnterAction { get; set; }
    }
}