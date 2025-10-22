using System;
using UnityEngine;

namespace Common.Interfaces
{
    public interface ITrigger
    {
        Action<ITrigger, Collider> OnTriggerEnterAction { get; set; }
    }
}