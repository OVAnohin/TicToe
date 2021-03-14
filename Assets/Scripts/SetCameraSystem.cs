using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> _filter;
        private SceneData _sceneData;
        private Configuration _configuration;

        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                var height = _configuration.LevelHeight;

                var camera = _sceneData.Camera;
                camera.orthographic = true;
                var size = height / 2f + (height - 1) * _configuration.Offcet.y / 2;
                camera.orthographicSize = size;

                _sceneData.CameraTransform.position = new Vector3(_configuration.LevelWidth / 2f + (_configuration.LevelWidth - 1) * _configuration.Offcet.y / 2, size, -size);
            }
        }
    }
}