using Leopotam.Ecs;
using UnityEngine;

namespace TicToe
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [SerializeField] private Configuration _configuration;
        [SerializeField] private SceneData  _sceneData;

        private void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new InitializeFieldSystem())
                .Add(new CreateCellViewSystem())
                .Add(new SetCameraSystem())
                // .Add (new TestSystem2 ())

                // register one-frame components (order is important), for example:
                .OneFrame<UpdateCameraEvent>()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                .Inject(_configuration)
                .Inject(_sceneData)
                // .Inject (new NavMeshSupport ())
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}