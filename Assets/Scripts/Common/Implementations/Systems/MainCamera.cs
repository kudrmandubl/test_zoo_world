using System.Linq;
using Common.Interfaces;
using UnityEngine;

namespace Common.Implementations
{
    public class MainCamera : IMainCamera
    {
        private UnityEngine.Camera _camera;

        public UnityEngine.Camera Camera => _camera;

        public MainCamera()
        {
            var camera = GameObject.FindAnyObjectByType<Camera>();
            _camera = camera;
        }
    }
}
