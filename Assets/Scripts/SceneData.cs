using UnityEngine;

namespace TicToe
{
    internal class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Camera _camera;

        public Transform CameraTransform => _cameraTransform;
        public Camera Camera => _camera;
    }
}