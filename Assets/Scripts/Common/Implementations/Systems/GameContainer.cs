using Common.Interfaces;
using UnityEngine;

namespace Common.Implementations.Systems
{
    public class GameContainer : MonoBehaviour, IGameContainer
    {
        public Transform Container => transform;
    }
}